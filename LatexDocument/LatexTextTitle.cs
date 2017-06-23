namespace LatexDocument
{
    public class LatexTextTitle
    {

        public const string Huge = @"\Huge";
        public const string huge = @"\huge";

        public const string LARGE = @"\LARGE";
        public const string Large = @"\Large";
        public const string large = @"\large";

        public const string normalsize = @"\normalsize";

        public const string small = @"\small";
        public const string footnotesize = @"\footnotesize";
        public const string scriptsize = @"\scriptsize";
        public const string tiny = @"\tiny";

        /// <summary>
        /// Text of the title to be added in the document
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Size of the title to be added in the document
        /// </summary>
        public string Size { get; private set; }

        /// <summary>
        /// Instantiates a new LatexTextTitle object
        /// </summary>
        /// <param name="Text">Text of the title to be added in the document</param>
        public LatexTextTitle(string Text)
        {
            this.Text = Text;
            Size = null;
        }

        /// <summary>
        /// Instantiates a new LatexTextTitle object
        /// </summary>
        /// <param name="Text">Text of the title to be added in the document</param>
        /// <param name="Size">Size of the title to be added in the document</param>
        public LatexTextTitle(string Text, string Size)
        {
            this.Text = Text;
            this.Size = Size;
        }

    }
}
