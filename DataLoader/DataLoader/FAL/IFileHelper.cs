namespace DataLoader.FAL
{
    /// <summary>
    /// FilesHelper Interface - Easy to exchange for different file store
    /// </summary>
    public interface IFileHelper    
    {
        bool TryLoadXMLFile<T>(string filePath, out T node);
        bool TryGetDirectoryFileList(string path, out string[] fileList);
    }
}