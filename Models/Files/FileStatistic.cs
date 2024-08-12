using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Users;

namespace CarEdit_Server.Models.Files;

public class FileStatistic
{
    [Key] public long Id { get; set; }
    public DateTime UploadDataTime { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string? OrigFileName { get; set; }
    public string? FileName { get; set; }
    public FileOperationType OperationType { get; set; }
    public string? PluginName { get; set; }
}