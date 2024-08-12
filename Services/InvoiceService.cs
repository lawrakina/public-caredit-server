using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace CarEdit_Server.Services;

public enum InvoiceStatus
{
    Created,
    PreCheckout,
    Successful
}

public class InvoiceService(ApplicationContext context)
{
    /// <summary>
    /// - ЮKassa Live: 390540012:LIVE:50376 2024-05-20 12:51
    /// - ЮKassa Test: 381764678:TEST:85082 2024-05-13 07:15
    /// </summary>
    internal string ProviderToken = "390540012:LIVE:50376";
    //test
    //internal string ProviderToken = "381764678:TEST:85082";

    //caredit_bot_feature - test
    // internal string ProviderToken = "381764678:TEST:85100";

    private Random _random = new();

    public async Task<TelegramInvoice> CreateInvoice(Chat chat, User user, Lot lot)
    {
        var invoice = new TelegramInvoice()
        {
            chat_id = chat.Id,
            user_id = user.Id,
            product_id = (int)lot.Id,
            status = InvoiceStatus.Created,
            title = lot.Title,
            description = lot.Description,
            payload = $"{user.Id}-{chat.Id}-{lot.Id}-{_random.Next(100000, 999999)}",
            currency = lot.Currency,
            prices = JsonConvert.SerializeObject(new[] { new LabeledPrice("label", lot.Price) }),
            date_create = DateTime.Now
        };

        context.TelegramInvoices.Add(invoice);
        await context.SaveChangesAsync();
        return invoice;
    }

    public async Task<Lot> GetProduct(int file, int time)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Files == file && x.Time == time);
    }

    public async Task<Lot> GetProduct(int productId)
    {
        return await context.Products
            .Include(x => x.Tariff)
            .FirstOrDefaultAsync(x => x.Id == productId);
    }

    public async Task<bool> PreCheckout(PreCheckoutQuery query)
    {
        var invoice = await context.TelegramInvoices.FirstOrDefaultAsync(x => x.payload == query.InvoicePayload);
        if (invoice != null)
        {
            invoice.id_checkout = query.Id;
            invoice.date_checkout = DateTime.Now;
            invoice.status = InvoiceStatus.PreCheckout;
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> CompletePayment(User user, SuccessfulPayment message)
    {
        var invoice = await context.TelegramInvoices.FirstOrDefaultAsync(x => x.payload == message.InvoicePayload);
        if (invoice != null)
        {
            invoice.currency = message.Currency;
            invoice.provider_payment_charge_id = message.ProviderPaymentChargeId;
            invoice.telegram_payment_charge_id = message.TelegramPaymentChargeId;
            invoice.total_amount = message.TotalAmount;
            invoice.date_completed = DateTime.Now;
            invoice.status = InvoiceStatus.Successful;
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<TelegramInvoice> GetInvoice(string invoicePayload)
    {
        return await context.TelegramInvoices.FirstOrDefaultAsync(x => x.payload == invoicePayload);
    }
}