using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class UserTariff
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public long TariffId { get; set; }
    public Tariff? Tariff { get; set; }
    public int Days { get; set; }
}