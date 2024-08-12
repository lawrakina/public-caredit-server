using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Sales;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class SaleStatisticService(ApplicationContext context)
{
    public async Task NewSale(long selectedUserId, long lotId, string? adminName)
    {
        var lot = await context.Products.Include(x => x.Tariff).FirstOrDefaultAsync(t => t.Id == lotId);
        context.Sales.Add(new Sale
        {
            Date = DateTime.Now,
            UserId = selectedUserId,
            TariffPrice = lot.Price,
            TariffName = lot.Tariff?.Name,
            TariffResources = lot.Tariff?.MaxFilesPerDay,
            TariffEndDate = DateTime.Today.AddDays((double)lot.Tariff?.Days),
            LotTitle = lot.Title,
            LotType = lot.Type.ToString(),
            LotFiles = lot.Files,
            LotTime = lot.Time,
            AdminName = adminName
        });
        await context.SaveChangesAsync();
    }

    public async Task NewSaleFromKeySale(long userId, KeySale key, Lot lot)
    {
        context.Sales.Add(new Sale
        {
            Date = DateTime.Now,
            UserId = userId,
            TariffPrice = lot.Price,
            TariffName = lot.Tariff?.Name,
            TariffResources = lot.Tariff?.MaxFilesPerDay,
            TariffEndDate = DateTime.Today.AddDays((double)lot.Tariff?.Days),
            LotTitle = lot.Title,
            LotType = lot.Type.ToString(),
            LotFiles = lot.Files,
            LotTime = lot.Time,
            AdminName = $"KeySale, {key.Author}",
        });
        await context.SaveChangesAsync();
    }

    public async Task<List<Sale>> GetSalesAsync()
    {
        return await context.Sales.ToListAsync();
    }

    public async Task<List<Sale>> GetSalesByAdminAsync(string adminName)
    {
        return await context.Sales.Where(sale => sale.AdminName == adminName).ToListAsync();
    }
    public async Task<List<IdentityUser>> GetAdministratorsAsync()
    {
        return await context.Users.ToListAsync();
    }
}