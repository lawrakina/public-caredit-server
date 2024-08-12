using System.Security.Principal;
using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Sales;
using CarEdit_Server.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class UserService(
    ApplicationContext context,
    TariffsService tariffsService,
    UserResourcesManager userResourcesManager,
    SaleStatisticService saleStatisticService)
{
    public async Task<User> GetUserByTelegramId(string telegramId)
    {
        var telegramUser = await context.TelegramUsers
            .Where(u => u.TelegramId == long.Parse(telegramId))
            .FirstOrDefaultAsync();

        var user = await context.CeUsers
            .Where(u => u.Id == telegramUser.UserId)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> GetUser(string session)
    {
        var sessionItem = await context.Sessions.FirstOrDefaultAsync(x => x.Value == session);
        if (sessionItem == null) return null!;
        {
            var user = await context.CeUsers.FirstOrDefaultAsync(x => x.Id == sessionItem.UserId);
            return user!;
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await context.CeUsers.ToListAsync();
    }

    public async Task<ClientFullInfo> GetClientInfoByTelegramUser(long telergamId)
    {
        var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.TelegramId == telergamId);
        return await GetClientInfo(telegramUser.UserId);
    }

    public async Task<User> RegisterNewUser(Telegram.Bot.Types.User telegram)
    {
        var user = new User
        {
            UserName = telegram.Username, FirstName = telegram.FirstName,
            LastName = telegram.LastName, LanguageCode = telegram.LanguageCode, DataCreated = DateTime.Now
        };
        var telegramUser = new TelegramUser
        {
            TelegramId = telegram.Id, User = user
        };

        context.TelegramUsers.Add(telegramUser);
        context.CeUsers.Add(user);

        await context.SaveChangesAsync();

        context.UserResources.Add(new UserResources { UserId = user.Id, OperationCount = 0 });

        var defaultTariff = await context.Tariffs.FirstOrDefaultAsync(x => x.Days == 0 && x.MaxFilesPerDay == 0);
        context.UsersTariffs.Add(new UserTariff { UserId = user.Id, TariffId = defaultTariff.Id, Days = 0 });

        await context.SaveChangesAsync();

        return user;
    }

    public async Task<ClientFullInfo> GetClientInfo(long userId)
    {
        var user = await context.CeUsers.FirstOrDefaultAsync(x => x.Id == userId);
        var resources = await context.UserResources
            .Where(u => u.UserId == user.Id).FirstOrDefaultAsync();
        var tariffs = await context.UsersTariffs
            .Where(t => t.UserId == user.Id).Include(userTariff => userTariff.Tariff)
            .ToListAsync();
        var files = await context.UsersFiles
            .Where(f => f.UserId == user.Id).ToListAsync();
        var fileCount = files.Sum(x => x.Count);

        var client = new ClientFullInfo
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            LanguageCode = user.LanguageCode,
            Tariff = tariffs
                .Select(x => new ClientFullInfo.TariffDto { Title = x.Tariff?.Name, Days = x.Days })
                .ToList(),
            OperationCount = resources.OperationCount,
            ExtraFiles = fileCount
        };

        return client;
    }


    public async Task<TelegramUser> GetTelegramUserByUserId(long id)
    {
        return context.TelegramUsers.FirstOrDefault(x => x.UserId == id)!;
    }

    public async Task<List<UserFullInfo>> GetUsersWithFullInfo()
    {
        var users = await context.UsersTariffs
            .Include(ut => ut.User)
            .Include(ut => ut.Tariff)
            .SelectMany(ut => context.TelegramUsers.Where(tu => tu.UserId == ut.UserId).DefaultIfEmpty(),
                (ut, tu) => new { ut, tu })
            .SelectMany(
                utu => context.UserResources.Where(ur => ur.UserId == utu.ut.UserId).DefaultIfEmpty(),
                (utu, ur) => new UserFullInfo
                {
                    UserId = utu.ut.User!.Id,
                    UserName = utu.ut.User.UserName,
                    TelegramId = utu.tu.TelegramId,
                    Tariff = utu.ut.Tariff,
                    //TariffEndDate = ur.Days
                }
            )
            .ToListAsync();

        return users;
    }

    public async Task<bool> ApplyLot(long userId, Lot lot, IIdentity? userIdentity)
    {
        try
        {
            var tariff = await tariffsService.GetTariff(lot.TariffId);
            switch (lot.Type)
            {
                case LotType.File:
                    await tariffsService.AddFiles(userId, tariff);
                    break;
                case LotType.Tariff:
                    await tariffsService.ApplyTariff(userId, tariff);
                    await userResourcesManager.SetUserResourcesWithTariff(userId, tariff);
                    break;
                case LotType.Plugin:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            await saleStatisticService.NewSale(userId, lot.Id, userIdentity?.Name);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}