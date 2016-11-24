using System.Collections.Generic;
using Shared;
using WebServices.DAL;

namespace WebServices
{
    /// <summary>
    /// Service for Thin UI Client 
    /// </summary>
    public class FrontEndService : IFrontEndService
    {
        /// <summary>
        /// Retrieve list of nodes from database
        /// </summary>
        /// <returns>List of nodes</returns>
        public List<Node> GetNodes()
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            var nodes = databaseAccessLayer.GetNodes();
            return nodes;
        }
    }
}
