using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LatexDocument
{
    public class LatexFont
    {
        /// <summary>
        /// Default font of Latex document
        /// </summary>
        public static string DEFAULT_FONT = "garamond";

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
        /// Text type Default
        /// </summary>
        public const string TEXT_DEFAULT = "{0}";

        public const string TEXT_Huge = @"\Huge";
        public const string TEXT_huge = @"\huge";

        public const string TEXT_LARGE = @"\LARGE";
        public const string TEXT_Large = @"\Large";
        public const string TEXT_large = @"\large";

        public const string TEXT_normalsize = @"\normalsize";

        public const string TEXT_small = @"\small";
        public const string TEXT_footnotesize = @"\footnotesize";
        public const string TEXT_scriptsize = @"\scriptsize";
        public const string TEXT_tiny = @"\tiny";

        /// <summary>
        /// Color of the text
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Size of the text
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Type of the text (bold, italic, underline, etc.)
        /// </summary>
        public string Type { get; set; }

        public LatexFont()
        {

        }
    }
}