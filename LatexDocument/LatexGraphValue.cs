namespace LatexDocument
{
    public class LatexGraphValue
    {
        /// <summary>
        /// Value of the data to be represented in the graph
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Label of the data to be represented in the graph
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// Color of the data to be represented in the graph (only in PieGraph)
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Instantiates a new LatexGraphValue object
        /// </summary>
        /// <param name="Value">Value of the data to be represented in the graph</param>
        /// <param name="Label">Label of the data to be represented in the graph</param>
        public LatexGraphValue(int Value, string Label)
        {
            this.Value = Value;
            this.Label = Label;
            Color = null;
        }

        /// <summary>
        /// Instantiates a new LatexGraphValue object
        /// </summary>
        /// <param name="Value">Value of the data to be represented in the graph</param>
        /// <param name="Label">Label of the data to be represented in the graph</param>
        /// <param name="Color">Color of the data to be represented in the graph (only in PieGraph)</param>
        public LatexGraphValue(int Value, string Label, string Color)
        {
            this.Value = Value;
            this.Label = Label;
            this.Color = Color;
        }
    }
}
