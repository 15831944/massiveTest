using System.Collections.Generic;
using Shared;
using WebServices.DAL;

namespace WebServices
{
    /// <summary>
    /// Service for DataUplaoder
    /// </summary>
    public class DataManagementService : IDataManagementService
    {
        /// <summary>
        /// Upload new data into database
        /// </summary>
        /// <param name="nodesList">List of nodes to upload</param>
        /// <returns> return count of nodes uploaded </returns>
        public int UploadNewData(List<Node> nodesList)
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            int nodesListCount = databaseAccessLayer.Insert(nodesList);
            return nodesListCount;
        }
    }
}
