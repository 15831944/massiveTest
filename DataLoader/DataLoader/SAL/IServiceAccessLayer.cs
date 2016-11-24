using System.Collections.Generic;
using Shared;

namespace DataLoader.SAL
{
    /// <summary>
    /// IService layer provides communication with server
    /// </summary>
    public interface IServiceAccessLayer
    {
        /// <summary>
        /// Uploads new data to server
        /// </summary>
        /// <param name="nodesList">List of nodes for upload</param>
        /// <returns>How many nodes send to server</returns>
        int UploadNewData(List<Node> nodesList);
    }
}