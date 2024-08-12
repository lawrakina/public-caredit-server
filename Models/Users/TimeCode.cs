using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Users;

public class TimeCode
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public int Code { get; set; }
    public bool IsAlive { get; set; }
    public bool Activated { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime ActivatedDateTime { get; set; }
}