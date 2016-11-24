using System.Collections.Generic;
using DataLoader.Service_References.DataManagementServiceReference;
using Shared;

namespace DataLoader.SAL
{
    /// <summary>
    /// Service layer provides communication with server
    /// </summary>
    internal class ServiceAccessLayer : IServiceAccessLayer
    {
        /// <summary>
        /// Uploads new data to server
        /// </summary>
        /// <param name="nodesList">List of nodes for upload</param>
        /// <returns>How many nodes send to server</returns>
        public int UploadNewData(List<Node> nodesList)
        {
            var client = new DataManagementServiceClient();
            var returnString = client.UploadNewData(nodesList.ToArray());
            return returnString;
        }
    }
}