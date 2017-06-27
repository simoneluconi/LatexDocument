namespace LatexDocument
{
    public class LatexTable
    {
        /// <summary>
        /// Matrix of elements to be added in the table
        /// </summary>
        public string[,] Elements { get; private set; }

        /// <summary>
        /// Show table borders
        /// </summary>
        public bool Borders { get; set; }

        /// <summary>
        /// Wrap table in the text
        /// </summary>
        public bool Wrap { get; set; }

        /// <summary>
        /// Instantiates a new LatexTable object
        /// </summary>
        /// <param name="Elements">Matrix of elements to be added in the table</param>
        /// <param name="Borders">Show table borders</param>
        /// <param name="Wrap">Wrap table in the text</param>
        public LatexTable(string[,] Elements, bool Borders = true, bool Wrap = false)
        {
            this.Elements = Elements;
            this.Borders = Borders;
            this.Wrap = Wrap;
        }
    }
}
