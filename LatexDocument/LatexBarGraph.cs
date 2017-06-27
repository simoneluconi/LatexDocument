using System.Collections.Generic;
namespace LatexDocument
{
    public class LatexBarGraph
    {
        List<LatexGraphValue> values;

        /// <summary>
        /// Specify if the graph should be centered
        /// </summary>
        public bool Centered { get; set; }

        /// <summary>
        /// Fill color of the bar graph
        /// </summary>
        public string BarColor { get; private set; }

        /// <summary>
        /// Instantiates a new LatexBarGraph object
        /// </summary>
        /// <param name="Values">Values to be added in the graph<</param>
        /// <param name="BarColor">Fill color of the bar graph</param>
        /// <param name="Centered">Specify if the graph should be centered</param>
        public LatexBarGraph(List<LatexGraphValue> Values, string BarColor = "blue", bool Centered = true)
        {
            values = new List<LatexGraphValue>();
            values.AddRange(Values);

            this.BarColor = BarColor;
            this.Centered = Centered;
        }

        /// <summary>
        /// Data of the graph
        /// </summary>
        public List<LatexGraphValue> Values
        {
            get
            {
                return values;
            }
        }
    }
}
