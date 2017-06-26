using System.Collections.Generic;

namespace LatexDocument
{
    public class LatexPieGraph
    {
        List<LatexGraphValue> values;

        /// <summary>
        /// Specify if the graph should be centered
        /// </summary>
        public bool Centered { get; set; }

        /// <summary>
        /// Instantiates a new LatexPieGraph object
        /// </summary>
        /// <param name="Values">Values to be added in the graph</param>
        public LatexPieGraph(List<LatexGraphValue> Values, bool Centered = true)
        {
            values = new List<LatexGraphValue>();
            values.AddRange(Values);
            this.Centered = Centered;
        }

        /// <summary>
        /// Values to be added in the graph
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
