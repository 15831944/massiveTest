using System.Collections.Generic;
using System.Windows;
using Client.Entities;
using Client.Utilities;

namespace ClientUnitTests
{
    public class NodesEventHandlerMock : INodesEventHandler
    {
        public NodesEventHandlerMock(List<NodeWithVisuals> nodesSelected, Dictionary<int, NodeWithVisuals> nodesWithVisuals)
        {
                
        }

        public void NodeSelected(object sender, RoutedEventArgs e)
        {
                
        }
    }
}