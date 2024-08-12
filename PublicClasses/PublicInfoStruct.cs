namespace CarEdit_server.PublicClasses;

public struct PublicInfoStruct
{
    public int UserOperationCount { get; set; }
    public int UserCount { get; set; }
    public int PluginCount { get; set; }
    public int SaveFileCount { get; set; }
    public int OpenFileCount { get; set; }
}