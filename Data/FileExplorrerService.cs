using AdminPanel.Data.Model;

public class FileExplorrerService(string rootPath)
{
    public Task<List<FileItem>> GetFilesAndDirectoriesAsync(string relativePath, DateTime? fromDate = null, DateTime? toDate = null)
    {
        if (string.IsNullOrEmpty(relativePath))
        {
            relativePath = string.Empty;
        }
        
        var fullPath = Path.Combine(rootPath, relativePath);
        var entries = Directory.GetFileSystemEntries(fullPath);
        
        var fileItems = new List<FileItem>();
        foreach (var entry in entries)
        {
            var fileInfo = new FileInfo(entry);
            var isDirectory = Directory.Exists(entry);
            var lastModified = fileInfo.LastWriteTime;

            if (fromDate.HasValue && lastModified < fromDate.Value)
            {
                continue;
            }
            if (toDate.HasValue && lastModified > toDate.Value)
            {
                continue;
            }

            fileItems.Add(new FileItem
            {
                Name = Path.GetFileName(entry),
                Path = Path.GetRelativePath(rootPath, entry),
                IsDirectory = isDirectory,
                LastModified = lastModified,
                FileCount = isDirectory ? Directory.GetFiles(entry).Length : (int?)null
            });
        }

        return Task.FromResult(fileItems);
    }

    public Task<int> GetTotalCountAsync(string relativePath, DateTime? fromDate = null, DateTime? toDate = null)
    {
        if (string.IsNullOrEmpty(relativePath))
        {
            relativePath = string.Empty;
        }
        
        var fullPath = Path.Combine(rootPath, relativePath);
        var entries = Directory.GetFileSystemEntries(fullPath);
        
        var fileItems = new List<FileItem>();
        foreach (var entry in entries)
        {
            var fileInfo = new FileInfo(entry);
            var lastModified = fileInfo.LastWriteTime;

            if (fromDate.HasValue && lastModified < fromDate.Value)
            {
                continue;
            }
            if (toDate.HasValue && lastModified > toDate.Value)
            {
                continue;
            }

            fileItems.Add(new FileItem());
        }

        return Task.FromResult(fileItems.Count);
    }

    public Task<byte[]> GetFileAsync(string relativePath)
    {
        var fullPath = Path.Combine(rootPath, relativePath);
        var fileBytes = File.ReadAllBytes(fullPath);
        return Task.FromResult(fileBytes);
    }
}