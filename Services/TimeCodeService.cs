using System.Globalization;
using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class TimeCodeService(IServiceScopeFactory serviceScopeFactory, UserService userService)
{
    private readonly Random _random = new();

    public async Task<GenerateCodeStruct> GenerateCode(Telegram.Bot.Types.User telegram)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        var codeStruct = new GenerateCodeStruct();

        if (telegram.Id == 0)
        {
            codeStruct.corrently = false;
            codeStruct.endTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            context.ListErrors.Add(new AuthError($"Telegram:{telegram.Id}", DateTime.Now, RequestCode.Error,
                $"telegram.FirstName:{telegram.FirstName}, telegram.UserName:{telegram.Username}, telegram.LastName:{telegram.LastName}"));
            await context.SaveChangesAsync();
            return codeStruct;
        }

        try
        {
            var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.TelegramId == telegram.Id);
            User user;
            if (telegramUser == null)
            {
                user = await userService.RegisterNewUser(telegram);
            }
            else
            {
                user = (await context.CeUsers.FirstOrDefaultAsync(x => x.Id == telegramUser.UserId))!;
            }

            user.LastActivity = DateTime.Now;

            var code = _random.Next(1000, 9999);

            for (var i = 0; i < 10; i++)
            {
                var tryCode = await context.TimeCodes.AnyAsync(x => x.Code == code);
                if (tryCode)
                {
                    code = _random.Next(1000, 9999);
                    continue;
                }

                break;
            }

            codeStruct.code = code;
            codeStruct.endDate = DateTime.Now + new TimeSpan(0, 5, 0);
            codeStruct.endTime = codeStruct.endDate.ToString(CultureInfo.InvariantCulture);
            context.TimeCodes.Add(new TimeCode()
            {
                UserId = user.Id, Code = codeStruct.code, EndDateTime = codeStruct.endDate, IsAlive = true,
                Activated = false
            });

            await context.SaveChangesAsync();

            await CheckTimers(context);

            codeStruct.corrently = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
            
        return codeStruct;
    }

    public async Task<CheckCodeStruct> CheckCode(string stringCode)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        var checkStruct = new CheckCodeStruct
        {
            userId = 0,
            requestCode = RequestCode.Error
        };

        await CheckTimers(context);

        if (!int.TryParse(stringCode, out var code))
        {
            return checkStruct;
        }

        var timer = await context.TimeCodes.FirstOrDefaultAsync(t => t.Code == code);

        if (timer == null)
        {
            checkStruct.requestCode = RequestCode.NotFoundCode;
            context.ListErrors.Add(new AuthError($"userId: {checkStruct.userId}", DateTime.Now,
                checkStruct.requestCode, $"Code {stringCode} not found"));
            await context.SaveChangesAsync();
            return checkStruct;
        }

        if (timer.Activated)
        {
            checkStruct.requestCode = RequestCode.AlreadyActivated;
            await context.SaveChangesAsync();
            return checkStruct;
        }

        if (!timer.IsAlive)
        {
            checkStruct.requestCode = RequestCode.TimeOut;
            await context.SaveChangesAsync();
            return checkStruct;
        }

        checkStruct.userId = timer.UserId;
        timer.ActivatedDateTime = DateTime.Now;
        timer.Activated = true;
        checkStruct.requestCode = RequestCode.Success;
        await context.SaveChangesAsync();

        return checkStruct;
    }

    private async Task CheckTimers(ApplicationContext context)
    {
        var timers = await context.TimeCodes.Where(t => t.EndDateTime < DateTime.Now).ToListAsync();

        foreach (var timer in timers)
        {
            timer.IsAlive = false;
        }

        await context.SaveChangesAsync();
    }
}
