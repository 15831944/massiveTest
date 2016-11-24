using System.Collections.Generic;
using System.ServiceModel;
using Shared;

namespace WebServices
{
    /// <summary>
    /// Service for Data Minig and path Fiding in graphs
    /// </summary>
    [ServiceContract]
    public interface IDomainSpecificService
    {
        /// <summary>
        /// Find Shortest path in graph, inside of databse. Currently use modified BFS alg.
        /// </summary>
        /// <param name="firstNodeId">Start node to search from</param>
        /// <param name="secondNodeId">Final node of path</param>
        /// <returns></returns>
        [OperationContract]
        List<Node> FindShortestPath(int firstNodeId, int secondNodeId);
    }
}
