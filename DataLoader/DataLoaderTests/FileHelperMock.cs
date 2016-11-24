using DataLoader.FAL;

namespace DataLoaderTests
{
    public class FileHelperMock  : IFileHelper
    {
        private readonly bool _tryLoadXMLFileSucces;
        private readonly bool _tryGetDirectoryFileListsucces;
        private readonly string[] _fileList;

        public FileHelperMock(bool tryLoadXMLFileSucces, bool tryGetDirectoryFileListsucces, string[] fileList)
        {
            this._tryLoadXMLFileSucces = tryLoadXMLFileSucces;
            this._tryGetDirectoryFileListsucces = tryGetDirectoryFileListsucces;
            _fileList = fileList;
        }

        public FileHelperMock(bool tryLoadXMLFileSucces, bool tryGetDirectoryFileListsucces)
        {
            this._tryLoadXMLFileSucces = tryLoadXMLFileSucces;
            this._tryGetDirectoryFileListsucces = tryGetDirectoryFileListsucces;
        }

        public bool TryLoadXMLFile<T>(string filePath, out T node)
        {
            node = default(T); 
            return _tryLoadXMLFileSucces;
        }

        public bool TryGetDirectoryFileList(string path, out string[] fileList)
        {
            fileList = _fileList;
            return _tryGetDirectoryFileListsucces;
        }
    }
}