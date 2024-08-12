using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Files;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public  class UserAccessService(ApplicationContext context)
{
    public  async Task<bool> CheckUserAccessToPluginCategory(long userId)
    {
        

        var userTariffs = await context.UsersTariffs.Include(u => u.Tariff).Where(x => x.UserId == userId).ToListAsync();
        if (userTariffs.Count == 0) return false;

        var lastFile = await context.LastFiles.FirstOrDefaultAsync(x => x.UserId == userId);
        var plugin = await context.Plugins.Include(p => p.Category).FirstOrDefaultAsync(p => p.Name == lastFile.Plugin);
        if (plugin == null) return false;

        var fullAccess = userTariffs.Any(t => t.Tariff?.CategoryId == 1); //Tariff for ALL categories
        var pluginAccess = userTariffs.Any(t => t.Tariff?.CategoryId == plugin.CategoryId);

        return fullAccess || pluginAccess;
    }

    public  async Task<bool> CheckAccessAlreadyGranted(long userId)
    {
        
        var result = await context.LastFiles.FirstOrDefaultAsync(x => x.UserId == userId);
        var allFiles = await context.FileStatistics
            .Where(x =>
                x.UserId == userId &&
                x.PluginName == result.Plugin &&
                x.FileName == result.LastFileName &&
                x.OperationType == FileOperationType.Download).ToListAsync();

        return allFiles.Count > 0;
    }
    
    public  async Task<RequestCode> CheckAccessHistoryFileAsync(long userId, string fileName)
    {
        
        var userFiles = await context.FileStatistics.Where(x => x.FileName == fileName || x.OrigFileName == fileName)
            .ToListAsync();

        if (userFiles.Any(x => x.UserId == userId))
        {
            return RequestCode.Success;
        }

        if (userFiles.Count > 0)
        {
            return RequestCode.Unauthorized;
        }

        return RequestCode.NotFoundCode;
    }
}