using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Files;

public class CeFile
{
    [Key] public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string? OrigPath { get; set; }
    public string? OrigFileName { get; set; }
    public string? PathName { get; set; }
    public string? FileName { get; set; }
    public string? SerializeData { get; set; }
    public DateTime LastActive { get; set; }
    public string? PluginName { get; set; }
}