using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Sales;

public class UpdateResourceItem
{
    [Key] public long Id { get; set; }
    public DateTime DateTime { get; set; }
    public int CountUpdateUsers { get; set; }
}