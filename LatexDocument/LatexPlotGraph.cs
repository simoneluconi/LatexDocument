namespace LatexDocument
{
    public class LatexPlotGraph
    {
        /// <summary>
        /// Title of the graph
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Label of the X axis
        /// </summary>
        public string XLabel { get; set; }

        /// <summary>
        /// Label of the Y axis
        /// </summary>
        public string YLabel { get; set; }

        /// <summary>
        /// Minimum value of X axis
        /// </summary>
        public int XMin { get; set; }

        /// <summary>
        /// Maximum value of X axis
        /// </summary>
        public int XMax { get; set; }

        /// <summary>
        /// Minimum value of Y axis
        /// </summary>
        public int YMin { get; set; }

        /// <summary>
        /// Maximum value of Y axis
        /// </summary>
        public int YMax { get; set; }

        /// <summary>
        /// Ticks of the X axis
        /// </summary>
        public int[] XTick { get; set; }

        /// <summary>
        /// Ticks of the Y axis
        /// </summary>
        public int[] YTick { get; set; }

        /// <summary>
        /// Position of the legend in the graph
        /// </summary>
        public string LegendPosition { get; set; }

        /// <summary>
        /// Style of the grid in the graph
        /// </summary>
        public string GridStyle { get; set; }

        /// <summary>
        /// Major grids in the Y axis
        /// </summary>
        public bool YMajorGrids { get; set; }

        /// <summary>
        /// Major grids in the X axis
        /// </summary>
        public bool XMajorGrids { get; set; }

        /// <summary>
        /// Specify if the graph should be centered
        /// </summary>
        public bool Centered { get; set; }

        /// <summary>
        /// Add a math expression. All other properties will be ignored.
        /// </summary>

        public LatexPlot[] Plots { get; set; }
        public LatexPlotGraph()
        {
            Centered = true;
        }
    }
}