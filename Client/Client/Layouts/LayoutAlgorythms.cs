using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using Client.Entities;
using Client.Utilities;

namespace Client.Layouts
{
    public class LayoutAlgorythms
    {
        public Dictionary<int, NodeWithVisuals> CreateGridlikeLayout(List<NodeWithVisuals> nodes, Canvas mainCanvas, List<NodeWithVisuals> nodesSelected)
        {
            var visualsFactory = new VisualsFactory();
            var nodesWithVisuals = new Dictionary<int, NodeWithVisuals>();
            var orderedNodes = nodes.OrderBy(o => o.adjacentNodes.Length).ToList();

            int stepSize = Definitions.Size + Definitions.HalfSize;

            int pointsToDeployPerCycle = 8;
            int cycleCounter = 0;
            int howManyCompleteCycles = 0;
            int pointsToDeployCounter = 1;
            double zerox = mainCanvas.ActualWidth / 2;
            double zeroy = mainCanvas.ActualHeight / 2;
            double x = zerox;
            double y = zeroy;
            foreach (var orderedNode in orderedNodes)
            {
                if (cycleCounter == pointsToDeployCounter)
                {
                    howManyCompleteCycles++;
                    pointsToDeployCounter = pointsToDeployPerCycle * howManyCompleteCycles; //cycle 1 = 8, cycle 2 = 16, cycle 3 = 24
                    cycleCounter = 0;
                    x = zerox;
                    y = zeroy;
                }

                if (cycleCounter == 0)
                {
                    x = zerox + (howManyCompleteCycles * stepSize); //cycle 1 = x = 4,0 cycle 2= x = 8,0
                }

                else if (cycleCounter > 0 && cycleCounter <= howManyCompleteCycles)
                {
                    y = y + stepSize;
                }

                else if (cycleCounter > howManyCompleteCycles && cycleCounter <= howManyCompleteCycles * 3)
                {
                    x = x - stepSize;
                }

                else if (cycleCounter > howManyCompleteCycles * 3 && cycleCounter <= howManyCompleteCycles * 5)
                {
                    y = y - stepSize;
                }

                else if (cycleCounter > howManyCompleteCycles * 5 && cycleCounter <= howManyCompleteCycles * 7)
                {
                    x = x + stepSize;
                }

                else if (cycleCounter > howManyCompleteCycles * 7)
                {
                    y = y + stepSize;
                }

                var nodeVisual = visualsFactory.CreateNode(x, y, mainCanvas, orderedNode, new NodesEventHandler(nodesSelected, nodesWithVisuals).NodeSelected);
                orderedNode.VisualRepresentation = nodeVisual;
                orderedNode.X = x;
                orderedNode.Y = y;
                nodesWithVisuals.Add(orderedNode.id, orderedNode);
                cycleCounter++;
            }
            return nodesWithVisuals;
        }
        
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