using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class KeySaleInvoice
{
    [Key] public int Id { get; set; }
    public long TelegramId { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public long KeyId { get; set; }
    public KeySale Key { get; set; }
    public DateTime DateCreated { get; set; }
    public int? DependMessageId { get; set; }
}