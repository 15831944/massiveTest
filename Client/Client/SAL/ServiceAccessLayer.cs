using System.Collections.Generic;
using System.Linq;
using Client.DomainSpecificServiceReference;
using Client.Entities;
using Shared;

namespace Client.SAL
{

    /// <summary>
    /// Layer to access Server
    /// </summary>
    class ServiceAccessLayer
    {
        /// <summary>
        /// Get a shortest path between start nad last node
        /// </summary>
        /// <param name="startNodeWithVisualsId">Start node to search from</param>
        /// <param name="lastNodeWithVisualsId">Final node for path</param>
        /// <returns>Array of nodes on shorthest path</returns>
        public Node[] GetShortestPathList(byte startNodeWithVisualsId, byte lastNodeWithVisualsId)
        {
            var client = new DomainSpecificServiceClient();
            var path = client.FindShortestPath(startNodeWithVisualsId, lastNodeWithVisualsId);
            return path;
        }

        /// <summary>
        /// Get nodes from database
        /// </summary>
        /// <returns>List of nodes from database</returns>
        public List<NodeWithVisuals> GetNodes()
        {
            //List<NodeWithVisuals> nodes = Test.GetTestData();
            //return nodes;
            var client = new FrontEndServiceReference.FrontEndServiceClient();
            var nodes = client.GetNodes();
            var nodesWitVisuals = nodes.Select(node => new NodeWithVisuals(node));
            return nodesWitVisuals.ToList();
        }
    }
}
