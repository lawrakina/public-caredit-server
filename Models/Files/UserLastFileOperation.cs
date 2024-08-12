using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Files;

public class UserLastFileOperation
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string? LastFileName { get; set; }
    public int OperationCount { get; set; }
    public bool OperationCompleted { get; set; }
    public string? Plugin { get; set; }
    public DateTime DateTime { get; set; } = System.DateTime.MinValue;
}