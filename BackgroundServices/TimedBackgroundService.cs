using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarEdit_Server.Models.Sales;
using CarEdit_Server.TelegramBot;
using Microsoft.Extensions.DependencyInjection;

namespace CarEdit_Server.BackgroundServices
{
    public class TimedBackgroundService(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<TimedBackgroundService> logger,
        TelegramBrain telegramBrain)
        : BackgroundService
    {
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(10);
        private Timer _timer;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            telegramBrain.Start(Program.WorkMode);

            if (Program.WorkMode != WorkModeType.Release)
            {
                return Task.CompletedTask;
            }

            logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, _interval);

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            logger.LogInformation("Timed Background Service is working.");

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                var lastUpdate = await context.UpdateResourceItems.OrderByDescending(item => item.DateTime)
                    .FirstOrDefaultAsync();

                if (lastUpdate == null || lastUpdate.DateTime.Date < DateTime.UtcNow.Date)
                {
                    await UpdateUserOperationsBasedOnTariff(context);
                    await UpdateUserResourcesAndCounts(context);

                    await ClearingOldTimeCodes(context);
                    await ClearingOldSessions(context);
                }
            }
        }

        private async Task UpdateUserOperationsBasedOnTariff(ApplicationContext context)
        {
            var userTariffs = context.UsersTariffs
                .Include(ut => ut.User)
                .Include(ut => ut.Tariff);

            foreach (var userTariff in userTariffs)
            {
                var userResource = await context.UserResources
                    .FirstOrDefaultAsync(ur => ur.UserId == userTariff.UserId);

                if (userResource != null)
                {
                    userResource.OperationCount = userTariff.Tariff.MaxFilesPerDay;
                }
            }

            await context.SaveChangesAsync();
        }

        private async Task UpdateUserResourcesAndCounts(ApplicationContext context)
        {
            var usersToUpdate = await context.UserResources
                .Join(context.UsersTariffs.Include(x => x.Tariff),
                    ur => ur.UserId,
                    ut => ut.UserId,
                    (ur, ut) => new { UserResource = ur, UserTariff = ut })
                .Where(x => x.UserTariff.Tariff.MaxFilesPerDay > 0)
                .ToListAsync();

            foreach (var entry in usersToUpdate)
            {
                entry.UserResource.OperationCount = entry.UserTariff.Tariff.MaxFilesPerDay;
                entry.UserTariff.Days--;
            }

            var updateRecord = new UpdateResourceItem
            {
                DateTime = DateTime.UtcNow.Date,
                CountUpdateUsers = usersToUpdate.Count
            };
            context.UpdateResourceItems.Add(updateRecord);

            await context.SaveChangesAsync();
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async Task ClearingOldSessions(ApplicationContext context)
        {
            var expiryThreshold = DateTime.Now.AddDays(-7);

            var sessionsToDelete = context.Sessions.Where(s => s.UpdateDateTime < expiryThreshold).ToList();

            context.Sessions.RemoveRange(sessionsToDelete);

            await context.SaveChangesAsync();
        }

        private async Task ClearingOldTimeCodes(ApplicationContext context)
        {
            var list = context.TimeCodes.Where(x => x.EndDateTime < DateTime.Now);

            context.TimeCodes.RemoveRange(list);

            await context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
