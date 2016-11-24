using System.Collections.Generic;
using Shared;
using WebServices.DAL;
using WebServices.Utilities;

namespace WebServices
{
    /// <summary>
    /// Service for Data Minig and path Fiding in graphs
    /// </summary>
    public class DomainSpecificService : IDomainSpecificService
    {

        /// <summary>
        /// Find Shortest path in graph, inside of databse. Currently use modified BFS alg.
        /// </summary>
        /// <param name="firstNodeId">Start node to search from</param>
        /// <param name="secondNodeId">Final node of path</param>
        public List<Node> FindShortestPath(int firstNodeId, int secondNodeId)
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            List<Node> nodesUniList  = databaseAccessLayer.GetNodes();
            List<Node> nodesBiList = databaseAccessLayer.GetNodesBidirectional(nodesUniList);
            var breathSearchFirst = new BreathSearchFirst();
            List<Node> resultNodes = breathSearchFirst.FindShortestPath(nodesBiList, firstNodeId, secondNodeId);
            return resultNodes;
        }
    }
}
