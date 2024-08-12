using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Services;

namespace CarEdit_Server.Models.Payments;

public class TelegramInvoice
{
    [Key] public int id { get; set; }
    public string id_checkout { get; set; }
    public InvoiceStatus status { get; set; }
    public long chat_id { get; set; }
    public long user_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string payload { get; set; }
    public string currency { get; set; }
    public string prices { get; set; }
    public DateTime date_create { get; set; }
    public DateTime? date_checkout { get; set; }
    public DateTime? date_completed { get; set; }
    public string? provider_payment_charge_id { get; set; }
    public string? telegram_payment_charge_id { get; set; }
    public int? total_amount { get; set; }
    public int product_id { get; set; }
}