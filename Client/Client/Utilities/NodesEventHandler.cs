using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Client.Entities;

namespace Client.Utilities
{
    /// <summary>
    /// Event Handler Helper for node selection / deselection
    /// </summary>
    public class NodesEventHandler : INodesEventHandler
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
            var nodesVisualHelper =  new NodesVisualHelper();
            var border = sender as Border;
            if (border != null)
            {
                var borderId = border.Tag is byte ? (byte)border.Tag : 0;

                if (_nodesSelected.Count >= 2)
                {
                    nodesVisualHelper.ClearNodeSelected(_nodesSelected);
                }

                border.BorderBrush = Definitions.SelectionColor;
                _nodesSelected.Add(_nodesWithVisuals[borderId]);
                nodesVisualHelper.SelectLines(_nodesSelected);
                
            }
        }

        public void CreateEventHandlers(Canvas mainCanvas)
        {
            foreach (var nodeWithVisuals in _nodesWithVisuals)
            {
                Border nodeVisual =  new VisualsFactory().CreateNode(nodeWithVisuals.Value.X, nodeWithVisuals.Value.Y, mainCanvas, nodeWithVisuals.Value, NodeSelected);
                nodeWithVisuals.Value.VisualRepresentation = nodeVisual;
            }
        }
    }
}