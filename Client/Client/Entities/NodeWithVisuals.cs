using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using Shared;

namespace Client.Entities
{
    public class NodeWithVisuals : Node
    {
        public NodeWithVisuals PreviousNodeWithVisuals;
        public Border VisualRepresentation;
        public List<Line> Lines;
        public double X,Y;

        public NodeWithVisuals(Node node)
        {
            id = node.id;
            label = node.label;
            adjacentNodes = node.adjacentNodes;
        }

        internal NodeWithVisuals()
        {
           
        }
    }
}

