using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Client.Entities;
using Shared;

namespace Client.Utilities
{
    /// <summary>
    /// Helper to visualize changes in graph, select / deselect etc.
    /// </summary>
    internal class NodesVisualHelper
    {
        /// <summary>
        /// Deselect selected nodes
        /// </summary>
        /// <param name="nodesSelected">Nodes to de-select</param>
        public void ClearNodeSelected(List<NodeWithVisuals> nodesSelected)
        {
            foreach (var nodeWithVisual in nodesSelected)
            {
                nodeWithVisual.VisualRepresentation.BorderBrush = Brushes.Black;
                ClearSelectedLines(nodeWithVisual);
            }
            nodesSelected.Clear();
        }

        /// <summary>
        /// Deselect lines attached to node
        /// </summary>
        /// <param name="nodeWithVisuals">Node with lines for deselection</param>
        public void ClearSelectedLines(NodeWithVisuals nodeWithVisuals)
        {
            foreach (var line in nodeWithVisuals.Lines)
            {
                line.Stroke = Definitions.DefaultLineColor;
                Panel.SetZIndex(line, 0);
            }
        }

        /// <summary>
        /// Select lines between given nodes in path
        /// </summary>
        /// <param name="path">id of nodes on shortest path</param>
        /// <param name="nodesWithVisuals">all nodes in graph</param>
        /// <param name="nodesSelected">list of nodes selected</param>
        /// <param name="mainCanvas">canvas to draw selected lines</param>
        public void DrawPath(Node[] path, Dictionary<int, NodeWithVisuals> nodesWithVisuals, List<NodeWithVisuals> nodesSelected, Canvas mainCanvas)
        {
            var visualsFactory = new VisualsFactory();
            NodeWithVisuals previousNode = null;
            foreach (var node in path)
            {
                var currentNode = nodesWithVisuals[node.id];
                if (previousNode != null)
                {   //TODO better line marking, now it just add lines...after while will overflow
                    var lineVisual = visualsFactory.CreateLine(currentNode.X + Definitions.HalfSize, currentNode.Y + Definitions.HalfSize, previousNode.X + Definitions.HalfSize, previousNode.Y + Definitions.HalfSize, mainCanvas);
                    lineVisual.Stroke = Definitions.SelectionColor;
                    currentNode.Lines.Add(lineVisual);
                    currentNode.VisualRepresentation.BorderBrush = Definitions.SelectionColor;
                    nodesSelected.Add(currentNode);
                }
                previousNode = currentNode;
            }
        }

        /// <summary>
        /// Select all lines in given nodes
        /// </summary>
        /// <param name="nodesSelected">Node with lines to select</param>
        public void SelectLines(List<NodeWithVisuals> nodesSelected)
        {
            foreach (var node in nodesSelected)
            {
                foreach (var line in node.Lines)
                {
                    line.Stroke = Definitions.SelectionColor;
                    Panel.SetZIndex(line, 1);
                }
            }
        }

        /// <summary>
        /// Create lines between nodes
        /// </summary>
        /// <param name="nodesWithVisuals">List of nodes</param>
        /// <param name="mainCanvas">Canvas where to draw lines</param>
        public void CreateConnectingLines(Dictionary<int, NodeWithVisuals> nodesWithVisuals, Canvas mainCanvas)
        {
            int size = Definitions.Size;
            int halfSize = Definitions.HalfSize;
            var visualsFactory = new VisualsFactory();
            foreach (var nodeWithVisual in nodesWithVisuals)
            {
                var lines = new List<Line>();

                foreach (var adjacentNode in nodeWithVisual.Value.adjacentNodes)
                {
                    var adjecetNodeVisual = nodesWithVisuals.First(node => node.Key == adjacentNode);
                    if (nodeWithVisual.Key == adjecetNodeVisual.Key)
                    {
                        var lineVisualPartOne = visualsFactory.CreateLine(nodeWithVisual.Value.X + size - size / 10, nodeWithVisual.Value.Y + halfSize, adjecetNodeVisual.Value.X + size + size / 5, adjecetNodeVisual.Value.Y + size, mainCanvas);
                        lines.Add(lineVisualPartOne);

                        var lineVisualPArtTwo = visualsFactory.CreateLine(nodeWithVisual.Value.X + halfSize, nodeWithVisual.Value.Y + size - size / 10, adjecetNodeVisual.Value.X + size + size / 5, adjecetNodeVisual.Value.Y + size, mainCanvas);
                        lines.Add(lineVisualPArtTwo);
                    }
                    else
                    {
                        var lineVisual = visualsFactory.CreateLine(nodeWithVisual.Value.X + halfSize, nodeWithVisual.Value.Y + halfSize, adjecetNodeVisual.Value.X + halfSize, adjecetNodeVisual.Value.Y + halfSize, mainCanvas);
                        lines.Add(lineVisual);
                    }
                }
                nodeWithVisual.Value.Lines = lines;
            }
        }
    }
}