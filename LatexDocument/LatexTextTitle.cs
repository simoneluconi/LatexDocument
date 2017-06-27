namespace LatexDocument
{
    public class LatexTextTitle
    {
        /// <summary>
        /// Font of the title
        /// </summary>
        public LatexFont Font { get; set; }

        /// <summary>
        /// Text of the title to be added in the document
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Instantiates a new LatexTextTitle object
        /// </summary>
        /// <param name="Text">Text of the title to be added in the document</param>
        public LatexTextTitle(string Text)
        {
            this.Text = Text;
            Font = new LatexFont();
        }

        /// <summary>
        /// Instantiates a new LatexTextTitle object
        /// </summary>
        /// <param name="Text">Text of the title to be added in the document</param>
        /// <param name="Font">Font of the title</param>
        public LatexTextTitle(string Text, LatexFont Font)
        {
            this.Text = Text;
            this.Font = Font;
        }
    }
}
