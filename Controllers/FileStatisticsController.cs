using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Users;
using CarEdit_Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarEdit_Server.Controllers;

public class FileStatisticsController(ApplicationContext context, UserService userService) : Controller
{
    [HttpGet]
    public async Task Get()
    {
        var session = Request.Headers[Constants.Session];
        try
        {
            var user = await userService.GetUser(session);
            var response = await GetFilesStatistic(user.Id);
            await Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        catch (Exception e)
        {
            await Response.WriteAsync(
                JsonConvert.SerializeObject(new AuthError(session, DateTime.Now, RequestCode.Error, "Auth error")));
        }
    }

    private async Task<List<OperationStatistic>> GetFilesStatistic(long userId)
    {
        return await context.FileStatistics
            .Include(x => x.User)
            .Where(x => x.UserId == userId)
            .Select(x =>
                new OperationStatistic()
                {
                    DataTime = x.UploadDataTime,
                    OrigFileName = x.OrigFileName,
                    ModFileName = x.FileName,
                    OperationType = x.OperationType,
                    PluginName = x.PluginName
                }).ToListAsync();
    }
}