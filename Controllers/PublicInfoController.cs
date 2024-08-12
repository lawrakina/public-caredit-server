using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Files;
using CarEdit_server.PublicClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarEdit_Server.Controllers;

public class PublicInfoController(ApplicationContext context) : Controller
{
    [HttpGet]
    public async Task<string> Get()
    {
        var response = new PublicInfoStruct
        {
            UserOperationCount = await context.FileStatistics.CountAsync(),
            UserCount = await context.CeUsers.CountAsync(),
            PluginCount = await context.Plugins.CountAsync(),
            OpenFileCount = await context.FileStatistics.Where(x => x.OperationType == FileOperationType.Upload)
                .CountAsync(),
            SaveFileCount = await context.FileStatistics.Where(x => x.OperationType == FileOperationType.Download)
                .CountAsync(),
        };
        return JsonConvert.SerializeObject(response);
    }
}