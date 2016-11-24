using System.Collections.Generic;
using System.Linq;
using Shared;

namespace WebServices.Utilities
{
    public class BreathSearchFirst
    {
        public List<Node> FindShortestPath(List<Node> nodes, int firstNodeId, int secondNodeId)
        {
            List<Node> resultNodes = new List<Node>();

            var startNode = nodes.First(node => node.id == firstNodeId);
            var lastNode = nodes.First(node => node.id == secondNodeId);
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(startNode);
            startNode.Cost = 0;
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                foreach (var adjacentNode in currentNode.adjacentNodes)
                {
                    var nextNode = nodes.First(node => node.id == adjacentNode);
                    if (lastNode.id == nextNode.id)
                    {
                        nextNode.PreviousNode = currentNode;
                        CreatePath(nextNode, resultNodes);
                        return resultNodes;
                    }
                    if (nextNode?.Cost == -1)
                    {
                        nextNode.Cost = currentNode.Cost + 1;
                        nextNode.PreviousNode = currentNode;
                        queue.Enqueue(nextNode);
                    }
                }
            }
            return resultNodes;
        }

        private void CreatePath(Node currentNode, List<Node> resultNodes)
        {
            resultNodes.Add(currentNode);
            if (currentNode.PreviousNode != null)
            {
                CreatePath(currentNode.PreviousNode, resultNodes);
            }
        }
    }
}