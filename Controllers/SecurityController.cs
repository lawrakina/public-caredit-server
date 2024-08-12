using CarEdit_Server.Services;
using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VoltApi.Extentions;

namespace CarEdit_Server.Controllers;

public class SecurityController(ApplicationContext context, TimeCodeService timeCodeService) : Controller
{
    [HttpGet]
    public async Task CheckSession()
    {
        var session = Request.QueryString.ToString().Replace("?", "");

        var checkSession = await CheckSession(session);
        var response = JsonConvert.SerializeObject(checkSession);
        await Response.WriteAsync(response);
    }

    [HttpGet]
    public async Task CheckCode()
    {
        try
        {
            var code = Request.QueryString.ToString().Replace("?", "");
            var item = await timeCodeService.CheckCode(code);

            if (item.requestCode == RequestCode.Success)
            {
                var session = await CreateSession(item.userId);

                var response = new ConnectStruct
                {
                    Session = session,
                    Code = item.requestCode,
                    Info = "Success"
                };

                var result = JsonConvert.SerializeObject(response);
                await Response.WriteAsync(result);
            }
            else
            {
                var response = new ConnectStruct
                {
                    Session = "-1",
                    Code = item.requestCode,
                    Info = "Error",
                };

                await Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
        catch (Exception e)
        {
            var response = new ConnectStruct
            {
                Session = "-1",
                Info =
                    $"An error has occurred, please forward this to the developer. Exception:{e.Message}, Method:{e.TargetSite}, StackTrace:{e.StackTrace}",
                Code = RequestCode.Error
            };

            await Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    private async Task<ConnectStruct> CheckSession(string session)
    {
        var userSession =
            await context.Sessions.Include(item => item.User).FirstOrDefaultAsync(x => x.Value == session);
        if (userSession is not { User: not null }) //ToDo вставить проверку на "старую сессию"
            return new ConnectStruct
            {
                Code = RequestCode.NotFoundCode,
                Session = string.Empty,
                Info = "Need get code again"
            };
        userSession.UpdateDateTime = DateTime.Now;
        await context.SaveChangesAsync();
        return new ConnectStruct
        {
            Code = RequestCode.Success,
            Session = session,
            Info = "Ok"
        };
    }

    private async Task<string> CreateSession(long userId)
    {
        var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.UserId == userId);

        if (telegramUser == null)
        {
            context.ListErrors.Add(new AuthError($"UserId: {userId}", DateTime.Now, RequestCode.Error,
                "CreateSession: User not found"));
            await context.SaveChangesAsync();
            return string.Empty;
        }

        var hash = (telegramUser.UserId * (117 + 117 * DateTime.UtcNow.Microsecond)).ToString().GetHashString();

        context.Sessions.Add(new Session { UserId = telegramUser.UserId, Value = hash, UpdateDateTime = DateTime.Now });

        await context.SaveChangesAsync();

        return hash;
    }
}