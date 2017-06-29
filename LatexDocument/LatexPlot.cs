using System.Windows;

namespace LatexDocument
{
    public class LatexPlot
    {
        /// <summary>
        /// Color of the line in the graph
        /// </summary>
        public string LineColor { get; set; }

        /// <summary>
        /// Style of the marks in the line of the graph
        /// </summary>
        public string MarksStyle { get; set; }

        /// <summary>
        /// Coordinates of the point in the graph
        /// </summary>
        public Point[] Coordinates { get; set; }

        /// <summary>
        /// Text of the legend in the graph
        /// </summary>
        public string Legend { get; set; }

        public string Expression { get; set; }

        /// <summary>
        /// Add multiple elements to the graph
        /// </summary>

        public LatexPlot()
        {

        }
    }
}