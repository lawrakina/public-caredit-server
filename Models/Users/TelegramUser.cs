using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Users;

public class TelegramUser
{
    [Key] public long Id { get; set; }
    public long TelegramId { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}