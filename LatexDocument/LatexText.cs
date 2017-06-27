namespace LatexDocument
{
    public class LatexText
    {
        /// <summary>
        /// Text to be added in the document
        /// </summary>
        public string Text { private set; get; }

        /// <summary>
        /// Font of the Text
        /// </summary>
        public LatexFont Font { get; set; }

        /// <summary>
        /// Instantiates a new LatexText object
        /// </summary>
        /// <param name="Text">Text to be added in the document</param>
        /// <param name="Font">Font of the Text</param>
        public LatexText(string Text, LatexFont Font)
        {
            this.Text = Text;
            this.Font = Font;
        }

        /// <summary>
        /// Instantiates a new LatexText object
        /// </summary>
        /// <param name="Text">Text to be added in the document</param>
        public LatexText(string Text)
        {
            this.Text = Text;
            Font = new LatexFont();
        }

    }
}
