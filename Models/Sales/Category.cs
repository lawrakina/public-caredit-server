using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Sales;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Plugin> Plugins { get; set; }
}