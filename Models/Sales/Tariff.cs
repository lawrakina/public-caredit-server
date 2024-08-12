using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Sales;

public class Tariff
{
    [Key] public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Days { get; set; }
    public int MaxFilesPerDay { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}