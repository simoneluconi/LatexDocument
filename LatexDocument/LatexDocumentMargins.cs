
namespace LatexDocument
{
    public class LatexDocumentMargins
    {
        /// <summary>
        /// Document Top border spacing in inch
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// Document Bottom border spacing in inch
        /// </summary>
        public double Bottom { get; set; }

        /// <summary>
        /// Document Left border spacing in inch
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Document Right border spacing in inch
        /// </summary>
        public double Right { get; set; }

        /// <summary>
        /// Instantiates a new LatexDocumentMargins object
        /// </summary>
        /// <param name="Top">Document Top border spacing in inch</param>
        /// <param name="Bottom">Document Bottom border spacing in inch</param>
        /// <param name="Left">Document Left border spacing in inch</param>
        /// <param name="Right">Document Right border spacing in inch</param>
        public LatexDocumentMargins(double Top, double Bottom, double Left, double Right)
        {
            this.Top = Top;
            this.Bottom = Bottom;
            this.Left = Left;
            this.Right = Right;
        }

        /// <summary>
        /// Instantiates a new LatexDocumentMargins object
        /// </summary>
        /// <param name="Margin">Document Top, Bottom, Left, Right borders spacing in inch</param>
        public LatexDocumentMargins(double Margin)
        {
            Top = Margin;
            Bottom = Margin;
            Left = Margin;
            Right = Margin;
        }

        /// <summary>
        /// Instantiates a new LatexDocumentMargins object with default borders spacing
        /// </summary>
        public LatexDocumentMargins()
        {
            Top = 1;
            Bottom = 1;
            Left = 1.25;
            Right = 1.25;
        }
    }
}
