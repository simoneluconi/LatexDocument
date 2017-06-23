using System.Collections.Generic;

namespace LatexDocument
{
    public class LatexPieGraph
    {
        List<LatexGraphValue> values;

        /// <summary>
        /// Instantiates a new LatexPieGraph object
        /// </summary>
        /// <param name="Values">Values to be added in the graph</param>
        public LatexPieGraph(List<LatexGraphValue> Values)
        {
            values = new List<LatexGraphValue>();
            values.AddRange(Values);
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
