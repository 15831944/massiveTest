using System.Collections.Generic;
using System.ServiceModel;
using Shared;

namespace WebServices
{
    /// <summary>
    /// Service for Thin UI Client 
    /// </summary>
   [ServiceContract]
    public interface IFrontEndService
    {
        /// <summary>
        /// Retrieve list of nodes from database
        /// </summary>
        /// <returns>List of nodes</returns>
        [OperationContract]
        List<Node> GetNodes();
    }
}
