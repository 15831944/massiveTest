using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DataLoader.FAL;
using DataLoader.SAL;
using Shared;


namespace DataLoader
{
    /// <summary>
    /// DataUploader for easy upload to desired server
    /// </summary>
    public class DataUploader     
    {
        readonly int _maxBatchSize;
        private readonly IFileHelper _fileHelper;
        private readonly IServiceAccessLayer _serviceAccessLayer;

        /// <summary>
        /// FileHelper for access to source files, ServiceAccessLayer for access to server/database
        /// </summary>
        /// <param name="maxBatchSize">Max size for continuous upload to server</param>
        /// <param name="fileHelper">FileHelper for access to source files</param>
        /// <param name="serviceAccessLayer">ServiceAccessLayer for access to server/database</param>
        public DataUploader(int maxBatchSize, IFileHelper fileHelper, IServiceAccessLayer serviceAccessLayer)
        {
            _maxBatchSize = maxBatchSize;
            _fileHelper = fileHelper;
            _serviceAccessLayer = serviceAccessLayer;
        }

        /// <summary>
        /// Load file from given path and upload them thru ServiceAccessLayer to server/database
        /// </summary>
        /// <param name="path">Path to Directory with source files</param>
        /// <returns>Count of files send to server</returns>
        public int LoadAndSendData(string path)
        {
            string[] fileList = LoadFileList(path, _fileHelper);
            if (fileList.Length > 0)
            {
                SendDataContinuously(fileList, _fileHelper);
            }
            return fileList.Length;
        }

       
        private void SendDataContinuously(string[] fileList, IFileHelper fileHelper)
        {
            ConcurrentQueue<string> fileQueue = new ConcurrentQueue<string>(fileList);
            var nodesList = new List<Node>();
            string filePath;
            while (fileQueue.TryDequeue(out filePath))
            {
                DeserializeFileAndAddNode(filePath, fileHelper, ref nodesList);
                CheckMaxBatchSizeAndSend(nodesList);
            }

            if (nodesList.Any())
            {
                SendNodes(nodesList);
            }
        }

        private void CheckMaxBatchSizeAndSend(List<Node> nodesList)
        {
            if (nodesList.Count >= _maxBatchSize)
            {
                SendNodes(nodesList);
                nodesList.Clear();
            }
        }

        private void SendNodes(List<Node> nodesList)
        {
            int returnCount = _serviceAccessLayer.UploadNewData(nodesList);
            Console.WriteLine("New nodes send to server count: " + nodesList.Count + ", Server saved count: " + returnCount);
        }

        private Node DeserializeFileAndAddNode(string filePath, IFileHelper fileHelper, ref List<Node> nodesList)
        {
            Node node;
            if (fileHelper.TryLoadXMLFile<Node>(filePath, out node))
            {
                nodesList.Add(node);
            }
            return node;
        }

        private string[] LoadFileList(string path, IFileHelper fileHelper)
        {
            string[] fileList;
            bool filesFound = fileHelper.TryGetDirectoryFileList(path, out fileList);
            
            if (!filesFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfortunately no files found in path: " + path);
                Console.ForegroundColor = ConsoleColor.White;
                return fileList;
            }
            return fileList;
        }
    }
}