using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class UserFile
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public int Count { get; set; }
}