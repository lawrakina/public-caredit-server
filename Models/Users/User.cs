using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.Files;

namespace CarEdit_Server.Models.Users;

public class User
{
    [Key] public long Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DataCreated { get; set; }
    public DateTime LastActivity { get; set; }
    public string? LanguageCode { get; set; }
    public List<CeFile> FilesList { get; set; } = new();
}