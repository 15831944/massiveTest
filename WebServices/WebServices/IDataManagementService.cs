using System.Collections.Generic;
using System.ServiceModel;
using Shared;

namespace WebServices
{
    /// <summary>
    /// Service for upload new data into database, return count of nodes uploaded
    /// </summary>
    [ServiceContract]
    public interface IDataManagementService
    {
        /// <summary>
        /// Upload new data into database
        /// </summary>
        /// <param name="nodesList">List of nodes to upload</param>
        /// <returns> return count of nodes uploaded </returns>
        [OperationContract]
        int UploadNewData(List<Node> nodesList);
    }
}
