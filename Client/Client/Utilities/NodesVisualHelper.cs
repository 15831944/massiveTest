using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Client.Entities;
using Shared;

namespace Client.Utilities
{
    internal class NodesVisualHelper    
    {
        public void ClearNodeSelected(List<NodeWithVisuals> nodesSelected)
        {
            foreach (var nodeWithVisual in nodesSelected)
            {
                nodeWithVisual.VisualRepresentation.BorderBrush = Brushes.Black;
                ClearSelectedLines(nodeWithVisual);
            }
            nodesSelected.Clear();
        }

        public void ClearSelectedLines(NodeWithVisuals nodeWithVisuals)
        {
            foreach (var line in nodeWithVisuals.Lines)
            {
                line.Stroke = Definitions.DefaultLineColor;
                Panel.SetZIndex(line, 0);
            }
        }

        public void DrawPath(Node[] path, Dictionary<int, NodeWithVisuals> nodesWithVisuals, List<NodeWithVisuals> nodesSelected, Canvas mainCanvas)
        {
            var visualsFactory = new VisualsFactory();
            NodeWithVisuals previousNode = null;
            foreach (var node in path)
            {
                var currentNode = nodesWithVisuals[node.id];
                if (previousNode != null)
                {
                    var lineVisual = visualsFactory.CreateLine(currentNode.X + Definitions.HalfSize, currentNode.Y + Definitions.HalfSize, previousNode.X + Definitions.HalfSize, previousNode.Y + Definitions.HalfSize, mainCanvas);

                    lineVisual.Stroke = Definitions.SelectionColor;
                    currentNode.Lines.Add(lineVisual);
                    currentNode.VisualRepresentation.BorderBrush = Definitions.SelectionColor;
                    nodesSelected.Add(currentNode);
                }
                previousNode = currentNode;
            }
        }

    }
}