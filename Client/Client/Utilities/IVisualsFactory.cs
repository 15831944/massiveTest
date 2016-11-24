using System.Windows.Controls;
using System.Windows.Input;
using Client.Entities;

namespace Client.Utilities
{
    public interface IVisualsFactory
    {
        Border CreateNode(double x, double y, Canvas mainCanvas, NodeWithVisuals orderedNode, MouseButtonEventHandler nodeSelected);
    }
}