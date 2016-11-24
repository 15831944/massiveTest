using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Client.Entities;

namespace Client.Layouts
{

    /// <summary>
    /// Layout algorythm class with different layout algorythms 
    /// </summary>
    public class LayoutAlgorythms
    {

        /// <summary>
        /// Grid like lyout with spread of nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="mainCanvas"></param>
        /// <returns></returns>
        public Dictionary<int, NodeWithVisuals> CreateGridlikeLayout(List<NodeWithVisuals> nodes, Canvas mainCanvas)
        {
            var nodesWithVisuals = new Dictionary<int, NodeWithVisuals>();
            var orderedNodes = nodes.OrderByDescending(o => o.adjacentNodes.Length).ToList(); //NOTE determines if "heavier" in the middle or on sides

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
                orderedNode.X = x;
                orderedNode.Y = y;
                nodesWithVisuals.Add(orderedNode.id, orderedNode);
                cycleCounter++;
            }
            return nodesWithVisuals;
        }
    }
}