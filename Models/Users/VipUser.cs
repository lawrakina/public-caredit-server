using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Users;

public class VipUser
{
    [Key] public long Id { get; set; }
    public long PhoneId { get; set; }
    public UserRights UserRights { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}