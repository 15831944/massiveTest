using System.Windows.Controls;
using System.Windows.Input;
using Client.Entities;
using Client.Utilities;

namespace ClientUnitTests
{
    public class VisualsFactoryMock : IVisualsFactory
    {
        public Border CreateNode(double x, double y, Canvas mainCanvas, NodeWithVisuals orderedNode,
            MouseButtonEventHandler nodeSelected)
        {
            return new Border();
            
        }
    }
}