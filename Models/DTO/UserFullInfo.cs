using CarEdit_Server.Models.Sales;

namespace CarEdit_Server.Models.DTO;

public class UserFullInfo
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public long? TelegramId { get; set; }
    public Tariff Tariff { get; set; }
    public double? TariffEndDate { get; set; }
}