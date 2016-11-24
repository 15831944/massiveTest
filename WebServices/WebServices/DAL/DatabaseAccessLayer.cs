using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace WebServices.DAL
{
    /// <summary>
    /// Layer for access to database
    /// </summary>
    public class DatabaseAccessLayer
    {
        /// <summary>
        /// Insert list of nodes into database
        /// </summary>
        /// <param name="nodesList">List of nodes for insert</param>
        public int Insert(List<Node> nodesList)
        {
            var adapter = new GraphTableAdapters.NodesTableAdapter();
            foreach (var node in nodesList)
            {
                try
                {
                    adapter.Insert(node.id, node.label, node.adjacentNodes);
                }
                catch (Exception e)
                {
                  // In case of fail rest of node is inserted
                }
            }
            return nodesList.Count;
        }

        /// <summary>
        /// Insert list of nodes into database as bulk
        /// </summary>
        /// <param name="nodesList">List of nodes fo insert</param>
        public void InsertBulk(List<Node> nodesList)
        {
            var adapter = new GraphTableAdapters.NodesTableAdapter();
            var newRecords = new Graph.NodesDataTable();
            foreach (var node in nodesList)
            {
                newRecords.AddNodesRow(node.id, node.label, node.adjacentNodes);
            }
            adapter.Update(newRecords);
        }

        /// <summary>
        /// Retrieves list of Nodes with UniDirectional relationships
        /// </summary>
        /// <returns> List of Nodes from database</returns>
        public List<Node> GetNodes()
        {
            var adapter = new GraphTableAdapters.NodesTableAdapter();
            Graph.NodesDataTable nodesBack = adapter.GetData();
            IEnumerable<Node> nodesList = nodesBack.Select(nodeBack => new Node
            {
                id = (byte)nodeBack.id, //TODO change in Node to long cause contract failure
                label = nodeBack.label,
                adjacentNodes = nodeBack.adjacentNodes
            });

            return nodesList.ToList();
        }

        /// <summary>
        /// Retrieves list of Nodes with BiDirectional relationships
        /// </summary>
        /// <param name="nodesUniList"></param>
        /// <returns> List of Nodes from database</returns>
        public List<Node> GetNodesBidirectional(List<Node> nodesUniList)
        {
            foreach (var node in nodesUniList)
            {
                foreach (var adjacentNodeId in node.adjacentNodes)
                {
                    var adjecentNode = nodesUniList.First(adjnode => adjnode.id == adjacentNodeId);
                    if (adjecentNode.adjacentNodes != null)
                    {
                        bool contains = adjecentNode.adjacentNodes.Contains(node.id);
                        if (!contains)
                        {
                            AddNodeToAdjecentNodes(adjecentNode, node.id, adjecentNode.adjacentNodes.ToList());
                        }
                    }
                    else
                    {
                        AddNodeToAdjecentNodes(adjecentNode, node.id, new List<byte>());
                    }
                }
            }
            return nodesUniList;
        }

        private void AddNodeToAdjecentNodes(Node adjecentNode, byte originalNodeId, List<byte> listOfAdjecentNodes)
        {
            List<byte> adjacentNodesList = listOfAdjecentNodes;
            adjacentNodesList.Add(originalNodeId);
            adjecentNode.adjacentNodes = adjacentNodesList.ToArray();
        }
    }
}