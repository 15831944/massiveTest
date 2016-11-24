using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Client.Entities;

namespace Client.Utilities
{
    /// <summary>
    /// Factory to create pre-set primitive type visuals
    /// </summary>
    public class VisualsFactory : IVisualsFactory
    {

        /// <summary>
        /// Creates Button
        /// </summary>
        /// <param name="name"></param>
        /// <param name="label"></param>
        /// <param name="buttonclickEventHandler"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        public Button CreateButton(string name, string label, RoutedEventHandler buttonclickEventHandler, Thickness margin)
        {
            var button = new Button
            {
                Name = name,
                Content = label,
                Margin = margin,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,

            };
            button.Click += buttonclickEventHandler;
            return button;
        }

        /// <summary>
        /// Creates Node visual, Border with Textblock
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="canvas"></param>
        /// <param name="node"></param>
        /// <param name="nodeSelected"></param>
        /// <returns></returns>
        public Border CreateNode(double x, double y, Canvas canvas, NodeWithVisuals node, MouseButtonEventHandler nodeSelected)
        {
            string name = node.label;
            byte id = node.id;
            int size = Definitions.Size;
            var textBlock = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = name,
                FontSize = size / 5,

            };
            var border = new Border
            {
                Child = textBlock,
                CornerRadius = new CornerRadius(50),
                //Margin =  new Thickness(10),
                Padding = new Thickness(0, size / 3, 0, 0),
                BorderThickness = new Thickness(2),

                Width = size,
                Height = size,
                Background = System.Windows.Media.Brushes.CornflowerBlue,
                BorderBrush = Brushes.Black,
                ToolTip = name,
                Tag = id

            };

            border.MouseLeftButtonDown += nodeSelected;
            canvas.Children.Add(border);
            Canvas.SetLeft(border, x);
            Canvas.SetTop(border, y);
            Panel.SetZIndex(border, 10);
            return border;
        }

        /// <summary>
        /// Create Line
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public Line CreateLine(double x1, double y1, double x2, double y2, Canvas canvas)
        {
            var myLine = new Line
            {
                Stroke = Definitions.DefaultLineColor,
                X1 = x1,
                Y1 = y1,

                X2 = x2,
                Y2 = y2,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = 2
            };

            canvas.Children.Add(myLine);
            Panel.SetZIndex(myLine, 0);
            return myLine;
        }

    }
}