using CarEdit_Server.Models.Files;

namespace CarEdit_Server.Models.DTO;

public class OperationStatistic
{
    public DateTime DataTime { get; set; }
    public FileOperationType OperationType { get; set; }
    public string PluginName { get; set; }
    public string OrigFileName { get; set; }
    public string ModFileName { get; set; }
}