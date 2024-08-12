using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class Sale
{
    [Key] public long Id { get; set; }
    public DateTime Date { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string TariffName { get; set; }
    public int TariffPrice { get; set; }
    public int? TariffResources { get; set; }
    public DateTime TariffEndDate { get; set; }
    public string? AdminName { get; set; }
    public string? LotTitle { get; set; }
    public string? LotType { get; set; }
    public int? LotFiles { get; set; }
    public int? LotTime { get; set; }
}