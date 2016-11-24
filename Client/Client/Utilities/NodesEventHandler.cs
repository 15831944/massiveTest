using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Client.Entities;

namespace Client.Utilities
{
    internal class NodesEventHandler    
    {
        private readonly List<NodeWithVisuals> _nodesSelected;
        private readonly Dictionary<int, NodeWithVisuals> _nodesWithVisuals;

        public NodesEventHandler(List<NodeWithVisuals> nodesSelected, Dictionary<int, NodeWithVisuals> nodesWithVisuals)
        {
            _nodesSelected = nodesSelected;
            _nodesWithVisuals = nodesWithVisuals;
        }

        public void NodeSelected(object sender, RoutedEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                var borderId = border.Tag is byte ? (byte)border.Tag : 0;

                if (_nodesSelected.Count >= 2)
                {
                    new NodesVisualHelper().ClearNodeSelected(_nodesSelected);
                }

                border.BorderBrush = Definitions.SelectionColor;
                _nodesSelected.Add(_nodesWithVisuals[borderId]);
                foreach (var node in _nodesSelected)
                {
                    foreach (var line in node.Lines)
                    {
                        line.Stroke = Definitions.SelectionColor;
                        Panel.SetZIndex(line, 1);
                    }
                }
            }
        }
    }
}