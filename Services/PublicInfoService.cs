using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class PublicInfoService(ApplicationContext context)
{
    public async Task<List<UserStatistics>> GetAllUserAnalytics()
    {
        var users = await context.CeUsers.ToListAsync();
        var fileStats = await context.FileStatistics.ToListAsync();

        var userStatisticsList = users.Select(user => new UserStatistics
        {
            UserId = user.Id,
            UserName = user.UserName,
            StatisticsByDay = fileStats.Where(stat => stat.UserId == user.Id)
                .GroupBy(stat => stat.UploadDataTime.Date)
                .Select(dayGroup => new StatisticsByDay
                {
                    Date = dayGroup.Key,
                    Operations = dayGroup.GroupBy(s => s.OperationType)
                        .Select(opGroup => new OperationCount
                        {
                            OperationType =
                                opGroup.Key.ToString(), // Адаптируйте эту часть, если ваш тип OperationType не строка
                            Count = opGroup.Count()
                        }).ToList()
                }).ToList()
        }).ToList();

        return userStatisticsList;
    }

    // public async Task PublicInfo(HttpContext context)
    // {
    //     var response = new PublicInfoStruct
    //     {
    //         UserOperationCount = await context.FileStatistics.CountAsync(),
    //         UserCount = await context.Users.CountAsync(),
    //         PluginCount = await context.Plugins.CountAsync(),
    //         OpenFileCount = await context.FileStatistics.Where(x => x.OperationType == FileOperationType.Upload)
    //             .CountAsync(),
    //         SaveFileCount = await context.FileStatistics.Where(x => x.OperationType == FileOperationType.Download)
    //             .CountAsync(),
    //     };
    //     await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    // }
}