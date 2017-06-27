namespace LatexDocument
{
    public class LatexParagraph
    {
        /// <summary>
        /// Text of the paragraph
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Heading of the paragraph
        /// </summary>
        public string Heading { get; private set; }

        /// <summary>
        /// Font of the paragraph
        /// </summary>
        public LatexFont Font { get; private set; }

        /// <summary>
        /// Instantiates a new LatexParagraph object
        /// </summary>
        /// <param name="Heading">Heading of the paragraph</param>
        /// <param name="Text">Text of the paragraph</param>
        public LatexParagraph(string Heading, string Text)
        {
            this.Heading = Heading;
            this.Text = Text;
            Font = new LatexFont();
        }

        /// <summary>
        /// Instantiates a new LatexParagraph object
        /// </summary>
        /// <param name="Text">Text of the paragraph</param>
        public LatexParagraph(string Text)
        {
            Heading = "";
            this.Text = Text;
            Font = new LatexFont();
        }

        /// <summary>
        /// Instantiates a new LatexParagraph object
        /// </summary>
        /// <param name="Heading">Heading of the paragraph</param>
        /// <param name="Text">Text of the paragraph</param>
        /// <param name="Font">Font of the paragraph</param>
        public LatexParagraph(string Heading, string Text, LatexFont Font)
        {
            this.Heading = Heading;
            this.Text = Text;
            this.Font = Font;
        }
    }
}
