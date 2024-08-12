using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class KeySale
{
    [Key] public long Id { get; set; }
    public string Key { get; set; }
    public long LotId { get; set; }
    public Lot? Lot { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public bool Activated { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime? ActivatedTime { get; set; }
    public DateTime? ExpireTime { get; set; }
    public string Author { get; set; }
    public long? UserId { get; set; }
    public User? User { get; set; }
}