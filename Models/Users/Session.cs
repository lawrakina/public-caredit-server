using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Users;

public class Session
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string Value { get; set; }
    public DateTime UpdateDateTime { get; set; }
}