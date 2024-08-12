namespace AdminPanel.Data.Model;

public class FileItem
{
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsDirectory { get; set; }
    public DateTime LastModified { get; set; }
    public int? FileCount { get; set; }
}