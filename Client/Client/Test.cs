using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Client.Entities;

namespace Client
{
    public class Test
    {
        public static List<NodeWithVisuals> GetTestData()
        {
            List<NodeWithVisuals> nodes = new List<NodeWithVisuals>
            {
                new NodeWithVisuals
                {
                    id = 9,
                    adjacentNodes = new byte[1] {10},
                    label = "Amazon"
                },
                new NodeWithVisuals
                {
                    id = 1,
                    adjacentNodes = new byte[2] {3,2},
                    label = "Apple"
                },
                new NodeWithVisuals
                {
                    id = 6,
                    adjacentNodes = new byte[2] {10,7},
                    label = "eBay"
                },
                new NodeWithVisuals
                {
                    id = 10,
                    adjacentNodes = new byte[1] {9},
                    label = "Facebook"
                },
                new NodeWithVisuals
                {
                    id = 3,
                    adjacentNodes = new byte[1] {5},
                    label = "Google"
                },
                new NodeWithVisuals
                {
                    id = 4,
                    adjacentNodes = new byte[0] {},
                    label = "IBM"
                },
                new NodeWithVisuals
                {
                    id = 2,
                    adjacentNodes = new byte[5] {1,10,5,9,7},
                    label = "Intel"
                },
                new NodeWithVisuals
                {
                    id = 7,
                    adjacentNodes = new byte[1] {6},
                    label = "Microsoft"
                },
                new NodeWithVisuals
                {
                    id = 5,
                    adjacentNodes = new byte[4] {2,8,5,7},
                    label = "Paypal"
                }
                ,
                new NodeWithVisuals
                {
                    id = 8,
                    adjacentNodes = new byte[1] {9},
                    label = "Yahoo"
                }

            };
            return nodes;
        }

        private void CreateEllipse(int x, int y, Canvas canvas, string name, int size)
        {
            // Create a red Ellipse.
            Ellipse myEllipse = new Ellipse
            {
                Fill = Brushes.YellowGreen,
                StrokeThickness = 2,
                Stroke = Brushes.Black
            };

            //myEllipse.MouseLeftButtonDown += NodeSelected;
            // Set the width and height of the Ellipse.
            myEllipse.Width = size;
            myEllipse.Height = size;


            // Add the Ellipse to the canvas.
            canvas.Children.Add(myEllipse);

            Canvas.SetLeft(myEllipse, x);
            Canvas.SetTop(myEllipse, y);
            Panel.SetZIndex(myEllipse, 1);

            var textBlock = new TextBlock
            {
                Text = name,
                IsHitTestVisible = false
            };

            //textBlock

            // Add the Ellipse to the canvas.
            canvas.Children.Add(textBlock);

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y + size / 4);
            Panel.SetZIndex(textBlock, 1);


        }


    }
}
