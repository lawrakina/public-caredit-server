using CarEdit_Server.Localize;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class TariffsService(ApplicationContext context)
{
    public async Task<Tariff> CreateTariff(Tariff tariff)
    {
        context.Tariffs.Add(tariff);
        await context.SaveChangesAsync();
        return tariff;
    }

    public async Task<Tariff> GetTariff(long id)
    {
        return await context.Tariffs.FindAsync(id);
    }

    public async Task<List<Tariff>> GetAllTariffs()
    {
        return await context.Tariffs.Include(x => x.Category).ToListAsync();
    }

    public async Task<Tariff> UpdateTariff(Tariff tariff)
    {
        context.Tariffs.Update(tariff);
        await context.SaveChangesAsync();
        return tariff;
    }

    public async Task DeleteTariff(long id)
    {
        var tariff = await context.Tariffs.FindAsync(id);
        if (tariff != null)
        {
            context.Tariffs.Remove(tariff);
            await context.SaveChangesAsync();
        }
    }

    public async Task ApplyTariff(long userId, Tariff tariff)
    {
        var userTariff = await context.UsersTariffs.FirstOrDefaultAsync(x => x.UserId == userId);

        if (userTariff != null)
        {
            context.UsersTariffs.Remove(userTariff);
        }

        userTariff = new UserTariff
        {
            UserId = userId,
            TariffId = tariff.Id,
            Days = tariff.Days
        };

        context.UsersTariffs.Add(userTariff);
        await context.SaveChangesAsync();
    }

    public async Task<string> AddFiles(long userId, Tariff tariff)
    {
        var message = String.Empty;

        var files = new UserFile()
        {
            UserId = userId,
            Count = tariff.MaxFilesPerDay,
        };
        context.UsersFiles.Add(files);
        await context.SaveChangesAsync();

        message = $"{Localization.ADD_FILES_WITH_TIME} {tariff.MaxFilesPerDay}";

        return message;
    }

    public async Task<string> RemakeTariff(long userId, Lot newLot, Tariff newTariff)
    {
        var fullLot = await context.Products
            .Where(x => x.Time == 365)
            .OrderByDescending(x => x.Price)
            .FirstOrDefaultAsync();
        var userTariffs = await context.UsersTariffs
            .Include(x => x.Tariff)
            .ThenInclude(tariff => tariff.Category)
            .Where(x => x.UserId == userId).ToListAsync();
        var userResource = await context.UserResources.FirstOrDefaultAsync(x => x.UserId == userId);

        if (userTariffs.Count == 0 || userResource == null || fullLot == null || newTariff == null)
        {
            return "Some necessary data is missing.";
        }

        var message = String.Empty;

        if (userTariffs.Count == 1 && userTariffs[0].Days == 0)
        {
            userTariffs[0].Tariff = newTariff;
            userTariffs[0].Days = newTariff.Days;

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            context.UsersTariffs.Update(userTariffs[0]);

            message = $"{Localization.CREATE_FULL_TARIFF} {newTariff.Days}";
        }
        else if (userTariffs.Count == 1 && userTariffs[0].Tariff?.CategoryId == 1 && newTariff.CategoryId == 1)
        {
            userTariffs[0].Days += newTariff.Days;

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            context.UsersTariffs.Update(userTariffs[0]);

            message = $"{Localization.ADD_DAYS_TO_FULL_TARIFF_CURRENT_DAYS} {userTariffs[0].Days}";
        }
        else if (userTariffs.Count == 1 && userTariffs[0].Tariff?.CategoryId == 1 && newTariff.CategoryId != 1)
        {
            userTariffs[0].Days += 365 * newLot.Price / fullLot.Price;

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            context.UsersTariffs.Update(userTariffs[0]);

            message = $"{Localization.ADD_FULL_TARIFF_FROM_TARIFF_CURRENT_DAYS} {userTariffs[0].Days}";
        }
        else if (userTariffs.All(x => x.Tariff?.CategoryId != 1)
                 && newTariff.CategoryId != 1
                 && userTariffs.Any(x => x.Tariff?.CategoryId == newTariff.CategoryId))
        {
            var userTariff = userTariffs.First(x => x.Tariff?.CategoryId == newTariff.CategoryId);
            userTariff.Days += newLot.Tariff.Days;

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            context.UsersTariffs.Update(userTariff);

            message = $"{Localization.ADD_DAYS_TO_YOU_TARIFF_CURRENT_DAYS} {userTariff.Days} {newTariff.Description}";
        }
        else if (userTariffs.All(x => x.Tariff?.CategoryId != 1)
                 && newTariff.CategoryId != 1
                 && userTariffs.All(x => x.Tariff?.CategoryId != newTariff.CategoryId))
        {
            var newUserTariff = new UserTariff
            {
                UserId = userId,
                TariffId = newTariff.Id,
                Days = newTariff.Days
            };
            context.UsersTariffs.Add(newUserTariff);

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            message = $"{Localization.ADD_NEW_TARIFF} {newTariff.Description}";
        }
        else if (userTariffs.All(x => x.Tariff?.CategoryId != 1) && newTariff.CategoryId == 1)
        {
            var costs = context.UsersTariffs
                .Include(x => x.Tariff)
                .Join(context.Products, x => x.TariffId, y => y.TariffId, (x, y) => new { x, y })
                .Where(x => x.x.UserId == userId)
                .Select(x => x.y.Price * x.x.Days / fullLot.Price)
                .Sum();

            context.UsersTariffs.RemoveRange(context.UsersTariffs.Where(x => x.UserId == userId));

            var newFullUserTariff = new UserTariff()
            {
                UserId = userId,
                TariffId = newTariff.Id,
                Days = newTariff.Days + costs
            };
            context.UsersTariffs.Add(newFullUserTariff);

            userResource.OperationCount = newTariff.MaxFilesPerDay;

            message = $"{Localization.CREATE_FULL_TARIFF_WITH_CULC_ALL_TARIFFS_CURRENT_DAYS} {newFullUserTariff.Days}";
        }

        context.UserResources.Update(userResource);
        await context.SaveChangesAsync();

        return message;
    }

    public async Task<List<UserTariff>> GetUserTariff(long userId)
    {
        return await context.UsersTariffs
            .Include(x => x.Tariff)
            .ThenInclude(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<int> GetUserFiles(long userId)
    {
        var userFiles = await context.UsersFiles.Where(x => x.UserId == userId).SumAsync(x => x.Count);
        return userFiles;
    }
}