using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Files;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public sealed class FileService(ApplicationContext context)
{
    public async Task SetOrigFile(long userId, string fileName, string origFileName, string fullPath,
        string origFullPath, string pluginName)
    {
        var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);

        if (item != null)
        {
            item.OrigPath = origFullPath;
            item.OrigFileName = origFileName;
            item.PathName = fullPath;
            item.FileName = fileName;
            item.LastActive = DateTime.Now;
            item.PluginName = pluginName;
        }
        else
        {
            item = new CeFile()
            {
                UserId = userId,
                OrigPath = origFullPath,
                OrigFileName = origFileName,
                FileName = fileName,
                PathName = fullPath,
                LastActive = DateTime.Now,
                PluginName = pluginName
            };
            context.Files.Add(item);
        }

        await AddStatistics(userId, item, FileOperationType.Upload);

        await context.SaveChangesAsync();
    }

    public async Task SetFileFromHistory(long userId, string fullPath, string fileName, string pluginName)
    {
        var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);

        if (item != null)
        {
            item.PathName = fullPath;
            item.FileName = fileName;
            item.LastActive = DateTime.Now;
            item.PluginName = pluginName;
        }
        else
        {
            item = new CeFile()
            {
                UserId = userId,
                FileName = fileName,
                PathName = fullPath,
                LastActive = DateTime.Now,
                PluginName = pluginName
            };
            context.Files.Add(item);
        }

        await AddStatistics(userId, item, FileOperationType.FromHistory);

        await context.SaveChangesAsync();
    }

    public async Task UpdateFile(long userId, byte[] openedFileBytes)
    {
        var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);
        if (item != null)
        {
            await using FileStream fstream = new(item.PathName, FileMode.OpenOrCreate);
            await fstream.WriteAsync(openedFileBytes, 0, openedFileBytes.Length);
        }
    }

    public async Task<string> GetPath(long userId)
    {
        var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);

        await AddStatistics(userId, item, FileOperationType.Download);

        return item?.PathName;
    }

    public async Task<string> GetFileName(long userId)
    {
        var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);

        return item?.FileName;
    }
    
    private async Task AddStatistics(long userId, CeFile ceFile, FileOperationType fileOperationType)
    {
        var itemStat = new FileStatistic()
        {
            UploadDataTime = DateTime.Now,
            UserId = userId,
            OrigFileName = ceFile.OrigFileName,
            FileName = ceFile.FileName,
            OperationType = fileOperationType,
            PluginName = ceFile.PluginName
        };

        context.FileStatistics.Add(itemStat);
        await context.SaveChangesAsync();
    }
}