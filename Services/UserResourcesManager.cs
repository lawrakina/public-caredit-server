using CarEdit_Server.Models;
using CarEdit_Server.Models.Files;
using CarEdit_Server.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class UserResourcesManager(ApplicationContext context, FileService fileService, DataService dataService)
{
    public async Task<UserResources> GetUserResources(long userId)
    {
        var resources = await context.UserResources.Where(u => u.UserId == userId).FirstOrDefaultAsync();

        return resources;
    }

    public async Task SetFileForUpdateUserResources(long userId, string fileName, string plugin, int operationCount = 0)
    {
        var lastFile = await context.LastFiles.FirstOrDefaultAsync(x => x.UserId == userId);
        if (lastFile == null)
        {
            context.LastFiles.Add(new UserLastFileOperation()
            {
                UserId = userId,
                LastFileName = fileName,
                OperationCount = operationCount,
                OperationCompleted = false,
                Plugin = plugin,
                DateTime = DateTime.Now
            });
        }
        else
        {
            lastFile.LastFileName = fileName;
            lastFile.OperationCount = operationCount;
            lastFile.OperationCompleted = false;
            lastFile.Plugin = plugin;
            lastFile.DateTime = DateTime.Now;
        }

        await context.SaveChangesAsync();
    }

    public async Task UpdateOperationForUserResources(long userId, string fileName)
    {
        var lastFile = await context.LastFiles
            .FirstOrDefaultAsync(x => x.UserId == userId && x.LastFileName == fileName);
        if (lastFile != null)
        {
            lastFile.OperationCount++;
            await dataService.AddStatistics(userId, lastFile.LastFileName, FileOperationType.Modify);
        }

        await context.SaveChangesAsync();
    }

    public async Task UpdateUserResources(long userId)
    {
        var userResources = await context.UserResources.FirstOrDefaultAsync(x => x.UserId == userId);

        var fileName = await fileService.GetFileName(userId);
        var lastFile =
            await context.LastFiles.FirstOrDefaultAsync(x => x.UserId == userId && x.LastFileName == fileName);

        if (userResources is { OperationCount: > 0 } && !lastFile.OperationCompleted)
        {
            userResources.OperationCount--;
            lastFile.OperationCompleted = true;

            await context.SaveChangesAsync();
            return;
        }

        var userFile = await context.UsersFiles.FirstOrDefaultAsync(x => x.UserId == userId && x.Count > 0);
        if (userFile is { Count: > 0 })
        {
            userFile.Count--;
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckUserResourcesFromTariffs(long userId)
    {
        var subResources = context.UserResources.FirstOrDefault(x => x.UserId == userId);

        return subResources is { OperationCount: > 0 };
    }

    public async Task<bool> CheckUserResourcesFromFiles(long userId)
    {
        var userFiles = context.UsersFiles.FirstOrDefault(x => x.UserId == userId && x.Count > 0);

        if (userFiles is { Count: > 0 })
        {
            return true;
        }

        return false;
    }

    public async Task SetUserResourcesWithTariff(long selectedUserId, Tariff tariff)
    {
        var userResource = await context.UserResources.FirstOrDefaultAsync(x => x.UserId == selectedUserId);
        userResource.OperationCount = tariff.MaxFilesPerDay;

        await context.SaveChangesAsync();
    }
}