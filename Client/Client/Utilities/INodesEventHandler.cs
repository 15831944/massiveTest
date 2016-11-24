using System.Windows;

namespace Client.Utilities
{
    public interface INodesEventHandler
    {
        void NodeSelected(object sender, RoutedEventArgs e);
    }
}