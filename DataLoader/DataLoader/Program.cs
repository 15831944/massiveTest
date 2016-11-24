using System;
using DataLoader.FAL;
using DataLoader.SAL;

namespace DataLoader
{
    /// <summary>
    /// Entry point for DataUploader :)
    /// </summary>
    class Program
    {
        private static string _path = "..\\..\\..\\..\\InputData";
        private static int maxBatchSize = 3;

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">args[0] may contain path to directory with files, otherwise default path is used</param>
        static void Main(string[] args)
        {

            Console.WriteLine("Data Loader starts");
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine("args count: " + args.Length);

            if (args.Length == 1)
            {
                _path = args[0];
            }

            var newFilesSendCount = new DataUploader(maxBatchSize, new FileHelper(), new ServiceAccessLayer()).LoadAndSendData(_path);
            Console.WriteLine("New files send to server, count: " + newFilesSendCount);
            Console.WriteLine("Data Loader finished job, Hit any key to end");
            Console.ReadKey();
        }
    }
}