using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;

namespace CarEdit_Server.Services;

public class TariffInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Days { get; set; }
    public string Category { get; set; }
}

public class UserTariffService(
    UserService userService,
    InvoiceService invoiceService,
    TariffsService tariffsService,
    SaleStatisticService saleStatisticService)
{
    public async Task SetUserTariff(long telegramId, string invoicePayload)
    {
        var user = await userService.GetUserByTelegramId(telegramId.ToString());
        var invoice = await invoiceService.GetInvoice(invoicePayload);
        var product = await invoiceService.GetProduct(invoice.product_id);
        var tariff = await tariffsService.GetTariff(product.TariffId);
        switch (product.Type)
        {
            case LotType.File:
                await tariffsService.AddFiles(user.Id, tariff);
                break;
            case LotType.Tariff:
                await tariffsService.RemakeTariff(user.Id, product, tariff);
                break;
            case LotType.Plugin:
                break;
        }

        await saleStatisticService.NewSale(user.Id, product.TariffId, "Telegram - yookassa");
    }

    public async Task<List<TariffInfo>> GetUserTariffsAsync(long telegramId)
    {
        var user = await userService.GetUserByTelegramId(telegramId.ToString());
        var userTariff = await tariffsService.GetUserTariff(user.Id);

        var result = new List<TariffInfo>();
        userTariff.Select(x => new TariffInfo()
        {
            Name = x.Tariff?.Name,
            Description = x.Tariff?.Description,
            Category = x.Tariff?.Category?.Name,
            Days = x.Days
        }).ToList().ForEach(x => result.Add(x));
        return result;
    }

    public async Task<int> GetUserFilesAsync(long telegramId)
    {
        var user = await userService.GetUserByTelegramId(telegramId.ToString());
        return await tariffsService.GetUserFiles(user.Id);
    }
}