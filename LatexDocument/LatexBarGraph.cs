using System.Collections.Generic;
namespace LatexDocument
{
    public class LatexBarGraph
    {
        List<LatexGraphValue> values;

        /// <summary>
        /// Fill color of the bar graph
        /// </summary>
        public string BarColor { get; private set; }

        /// <summary>
        /// Instantiates a new LatexBarGraph object
        /// </summary>
        /// <param name="Values">Values to be added in the graph</param>
        public LatexBarGraph(List<LatexGraphValue> Values)
        {
            values = new List<LatexGraphValue>();
            values.AddRange(Values);

            BarColor = "blue";
        }

        /// <summary>
        /// Instantiates a new LatexBarGraph object
        /// </summary>
        /// <param name="Values">Values to be added in the graph<</param>
        /// <param name="BarColor">Fill color of the bar graph</param>
        public LatexBarGraph(List<LatexGraphValue> Values, string BarColor)
        {
            values = new List<LatexGraphValue>();
            values.AddRange(Values);

            this.BarColor = BarColor;
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
