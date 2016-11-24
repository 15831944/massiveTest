using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Client.Entities;
using Client.Layouts;
using Client.SAL;
using Client.Utilities;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Canvas _mainCanvas;
        Dictionary<int, NodeWithVisuals> _nodesWithVisuals = new Dictionary<int, NodeWithVisuals>();
        private List<NodeWithVisuals> _nodesSelected = new List<NodeWithVisuals>();


        public MainWindow()
        {
            InitializeComponent();
            _mainCanvas = CreateDefaultCanvas();
            var scrollViewerCanvas = new ScrollViewer 
            {
                Content = _mainCanvas,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto
            }; //TODO fix not showing
            Content = scrollViewerCanvas;
        }

        private Canvas CreateDefaultCanvas()
        {
            Canvas defaultCanvas = new Canvas();
            CreateButtons(defaultCanvas);
            return defaultCanvas;
        }

        private void CreateButtons(Canvas defaultCanvas)
        {
            var visualsFactory = new VisualsFactory();
            Button buttonLoad = visualsFactory.CreateButton(Definitions.LoadButtonName, Definitions.LoadButtonLabel, loadButton_Click, new Thickness(5, 5, 0, 0));
            Button buttonPath = visualsFactory.CreateButton(Definitions.CalculateShortestPathButtonName, Definitions.CalculateShortestPathButtonLabel, pathButton_Click, new Thickness(80, 5, 0, 0));
            defaultCanvas.Children.Add(buttonLoad);
            defaultCanvas.Children.Add(buttonPath);
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            RestartCanvas(_mainCanvas);
            List<NodeWithVisuals> nodes = new ServiceAccessLayer().GetNodes();
            var layoutAlgorythm = new LayoutAlgorythms();
            _nodesWithVisuals = layoutAlgorythm.CreateGridlikeLayout(nodes, _mainCanvas);
            new NodesEventHandler(_nodesSelected, _nodesWithVisuals).CreateEventHandlers(_mainCanvas);
            new NodesVisualHelper().CreateConnectingLines(_nodesWithVisuals, _mainCanvas);
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            if (_nodesSelected.Count != 2)
            {
                MessageBox.Show("First you have to select 2 nodes, before calculating path");
                return;
            }
            
            NodeWithVisuals startNodeWithVisuals = _nodesSelected.First();
            NodeWithVisuals lastNodeWithVisuals = _nodesSelected.Last();
            var nodesVisualHelper = new NodesVisualHelper();
            nodesVisualHelper.ClearSelectedLines(startNodeWithVisuals);
            nodesVisualHelper.ClearSelectedLines(lastNodeWithVisuals);

            var path = new ServiceAccessLayer().GetShortestPathList(startNodeWithVisuals.id, lastNodeWithVisuals.id);

            nodesVisualHelper.DrawPath(path, _nodesWithVisuals, _nodesSelected, _mainCanvas);
        }

        private void RestartCanvas(Canvas mainCanvas)
        {
            mainCanvas.Children.Clear();
            CreateButtons(mainCanvas);
            _nodesWithVisuals = new Dictionary<int, NodeWithVisuals>();
            _nodesSelected = new List<NodeWithVisuals>();
        }
    }
}
