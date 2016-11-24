using System.Collections.Generic;
using System.Linq;
using Client.DomainSpecificServiceReference;
using Client.Entities;
using Shared;

namespace Client.SAL
{
    class ServiceAccessLayer
    {
        public Node[] GetShortestPathList(byte startNodeWithVisualsId, byte lastNodeWithVisualsId)
        {
            var client = new DomainSpecificServiceClient();
            var path = client.FindShortestPath(startNodeWithVisualsId, lastNodeWithVisualsId);
            return path;
        }

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
