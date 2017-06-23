namespace LatexDocument
{
    public class LatexText
    {
        /// <summary>
        /// Text type Bold
        /// </summary>
        public const string TEXT_BOLD = @"\textbf{{{0}}}";

        /// <summary>
        /// Text type Underlined
        /// </summary>
        public const string TEXT_UNDERLINE = @"\underline{{{0}}}";

        /// <summary>
        /// Text type Italic
        /// </summary>
        public const string TEXT_ITALIC = @"\textit{{{0}}}";

        /// <summary>
        /// Text to be added in the document
        /// </summary>
        public string Text { private set; get; }

        /// <summary>
        /// Text formatting
        /// </summary>
        public string Format { private set; get; }

        /// <summary>
        /// Instantiates a new LatexText object
        /// </summary>
        /// <param name="Text">Text to be added in the document</param>
        /// <param name="Format">Text formatting</param>
        public LatexText(string Text, string Format)
        {
            this.Text = Text;
            this.Format = Format;
        }

        /// <summary>
        /// Instantiates a new LatexText object
        /// </summary>
        /// <param name="Text">Text to be added in the document</param>
        public LatexText(string Text)
        {
            this.Text = Text;
            Format = null;
        }
    }
}
