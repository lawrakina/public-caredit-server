using System.ComponentModel.DataAnnotations;

namespace CarEdit_Server.Models.Sales;

public class Plugin
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public int? CategoryId { get; set; }
    public Category Category { get; set; }
    public int? ParentId { get; set; }
    public Plugin Parent { get; set; }
    public ICollection<Plugin> Children { get; set; }
    public string Icon { get; set; }
    public bool IsVisible { get; set; }
}