using System;
using System.IO;
using System.Xml.Serialization;

namespace DataLoader.FAL
{
    /// <summary>
    /// FileHelper is file access layer and used for file serialization and deserialization
    /// </summary>
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// Tries to read file and desirialize into desired T type.
        /// </summary>
        /// <typeparam name="T">Desired deserialised T object</typeparam>
        /// <param name="path">Path to file for deserialization</param>
        /// <param name="result">Deserialized file</param>
        /// <returns>if succes return true</returns>
        public bool TryLoadXMLFile<T>(string path, out T result)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    result = (T)serializer.Deserialize(reader);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem with deserialization occures, error message:" + e.Message );
                Console.ForegroundColor = ConsoleColor.White;
            }
            result = default(T);
            return false;
        }

        /// <summary>
        /// Get list of file inside given path
        /// </summary>
        /// <param name="path">Path to discover files</param>
        /// <param name="fileList">List of files in folder</param>
        /// <returns>Returns true if folder contains files</returns>
        public bool TryGetDirectoryFileList(string path, out string[] fileList)
        {
            if (Directory.Exists(path))
            {
                fileList = Directory.GetFiles(path);
                return true;
            }
            fileList = new string[0];
            return false;
        }
    }
}
