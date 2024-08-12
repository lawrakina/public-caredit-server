using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Sales;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using TelegramBot.Commands;
using VoltApi.Extentions;

namespace CarEdit_Server.Services;

public class KeyInfo
{
    public KeyInfoType Status { get; set; }
    public string Message { get; set; }
}

public struct ActivateInvoiceStruct
{
    public string KeySale;
    public string LotTitle;
    public bool Status;
    public string Message;
    public int? DependMessageId;
}

public enum KeyInfoType
{
    Incorrect,
    Live,
    TariffAlreadyActivated
}

public class KeySalesService(
    ApplicationContext context,
    UserService userService,
    TariffsService tariffsService,
    SaleStatisticService saleStatisticService,
    AuthenticationStateProvider authenticationStateProvider)
{
    public async Task<List<KeySale>> GetKeySalesAsync(string identityName)
    {
        return await context.KeySales
            .Where(x => x.Author == identityName)
            .Include(x => x.Lot)
            .ToListAsync();
    }

    public KeySale AddKeySale(KeySale newKeySale)
    {
        context.KeySales.Add(newKeySale);
        context.SaveChanges();

        return newKeySale;
    }

    public async Task<KeyInfo> CreateKeyInvoiceAsync(Commands.ICommandDictionary dictionary,
        User telegram, string keyText, int listMessageId)
    {
        var keyInfo = new KeyInfo();


        var key = await context.KeySales.Include(x => x.Lot).FirstOrDefaultAsync(x => x.Key == keyText);
        var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.TelegramId == telegram.Id);

        Models.Users.User user;
        if (telegramUser == null)
        {
            user = await userService.RegisterNewUser(telegram);
        }
        else
        {
            user = await context.CeUsers.FirstOrDefaultAsync(x => x.Id == telegramUser.UserId);
        }

        if (key == null || key.Activated || key.ExpireTime < DateTime.Now)
        {
            keyInfo.Status = KeyInfoType.Incorrect;
        }
        else
        {
            if (context.UsersTariffs.Any(x => x.UserId == user.Id && x.TariffId == key.Lot.TariffId))
            {
                keyInfo.Status = KeyInfoType.TariffAlreadyActivated;
                keyInfo.Message = $"{key.Lot?.Title}\r\n{dictionary.TariffAlreadyActivated}";
            }
            else
            {
                keyInfo.Status = KeyInfoType.Live;
                keyInfo.Message = $"{key.Lot?.Title}\r\n{dictionary.KeySaleWelcome}";
            }

            var invoice = new KeySaleInvoice()
            {
                TelegramId = telegram.Id,
                UserId = user.Id,
                KeyId = key.Id,
                DateCreated = DateTime.Now,
                DependMessageId = listMessageId
            };

            context.KeySaleInvoices.Add(invoice);

            await context.SaveChangesAsync();
        }

        return keyInfo;
    }

    public async Task CloseInvoiceAsync(long telegramId)
    {
        var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.TelegramId == telegramId);
        var user = await context.CeUsers.FirstOrDefaultAsync(x => x.Id == telegramUser.UserId);

        var invoices = await context.KeySaleInvoices.Where(x => x.UserId == user.Id).ToListAsync();

        context.RemoveRange(invoices);

        await context.SaveChangesAsync();
    }

    public async Task<ActivateInvoiceStruct> ActivateInvoiceAsync(long telegramId)
    {
        var result = new ActivateInvoiceStruct();
        try
        {
            var message = string.Empty;

            var telegramUser = await context.TelegramUsers.FirstOrDefaultAsync(x => x.TelegramId == telegramId);
            var user = await context.CeUsers.FirstOrDefaultAsync(x => x.Id == telegramUser.UserId);

            var invoice = await context.KeySaleInvoices
                .Include(x => x.Key)
                .ThenInclude(x => x.Lot)
                .ThenInclude(x => x.Tariff)
                .FirstOrDefaultAsync(x => x.UserId == user.Id);

            var key = invoice.Key;
            key.Activated = true;
            key.ActivatedTime = DateTime.Now;
            key.UserId = user.Id;

            var lot = key.Lot;
            var tariff = lot?.Tariff;

            switch (lot.Type)
            {
                case LotType.File:
                    message = await tariffsService.AddFiles(user.Id, tariff);
                    break;
                case LotType.Tariff:
                    message = await tariffsService.RemakeTariff(user.Id, lot, tariff);
                    break;
                case LotType.Plugin:
                    break;
            }

            await saleStatisticService.NewSaleFromKeySale(user.Id, key, lot);

            result.Status = true;
            result.KeySale = key.Key;
            result.LotTitle = lot.Title;
            result.Message = message;
            result.DependMessageId = invoice.DependMessageId;

            context.KeySaleInvoices.Remove(invoice);

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            result.Status = false;
            result.KeySale = "not found";
            result.LotTitle = "not found";
            result.Message = e.Message;
        }

        return result;
    }

    public async Task<List<KeySale>> GetKeySalesAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        return await GetKeySalesAsync(user.Identity?.Name);
    }

    public async Task<KeySale> CreateKeySaleAsync(KeySale newKeySale)
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        newKeySale.CreateTime = DateTime.Now;
        newKeySale.Author = user.Identity?.Name;
        newKeySale.Key = $"KEY:{(117 + 117 * DateTime.UtcNow.Microsecond).ToString().GetHashString().GenerateKey()}";
        newKeySale.Activated = false;

        return AddKeySale(newKeySale);
    }
}