using System.Windows.Media;

namespace Client
{
    /// <summary>
    /// Default values/cons
    /// </summary>
    class Definitions
    {
        public static SolidColorBrush SelectionColor = Brushes.Red;
        public static SolidColorBrush DefaultLineColor = Brushes.DarkGreen;
        public static int Size = 60;
        public static int HalfSize = Size / 2;
        public static string LoadButtonName=  "LoadButton";
        public static string CalculateShortestPathButtonName = "CalculateShortestPath";
        public static string LoadButtonLabel = "Load Graph";
        public static string CalculateShortestPathButtonLabel = "Calculate Shortest Path";
    }
}
