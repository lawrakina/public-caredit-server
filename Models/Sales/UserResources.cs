using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Sales;

public class UserResources
{
    [Key] public int Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public int OperationCount { get; set; }
}