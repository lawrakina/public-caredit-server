using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Sales;

namespace CarEdit_Server.Models.Payments;

public class Lot
{
    [Key] public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
    public long TariffId { get; set; }
    public Tariff? Tariff { get; set; }
    public LotType Type { get; set; }
    public int Files { get; set; }
    public int Time { get; set; }
}