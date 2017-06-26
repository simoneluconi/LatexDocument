using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LatexDocument;
using System.Drawing;
using ScintillaNET;

namespace LatexDocumentExample
{
    public partial class Form1 : Form
    {
        LatexDocument.Document lt;
        Scintilla TextArea;

        string LoremIpsum = Properties.Settings.Default.LoremIpsum;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            lt.CreatePdf("Test");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextArea = new Scintilla();
            TextPanel.Controls.Add(TextArea);

            // BASIC CONFIG
            TextArea.Dock = DockStyle.Fill;
            TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

            InitNumberMargin();

            lt = new LatexDocument.Document(@"C:\Program Files\MiKTeX 2.9\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");

            LatexPageTitle title = new LatexPageTitle("Test File", "Simone Luconi", "18 Giugno 2017");
            lt.Add(title);

            lt.Add(new LatexTextTitle("Big Title", LatexTextTitle.Huge));
            LatexImage img = new LatexImage(@"C:\Users\Matteo\Desktop\Giugno 2017\sfondo1.jpg", "Test Image");
            lt.Add(img);
            lt.Add(new LatexParagraph("Text", LoremIpsum));
            lt.NewLine();
            lt.Add(new LatexText("Bold text, ", LatexText.TEXT_BOLD));
            lt.Add(new LatexText("Italix text, ", LatexText.TEXT_ITALIC));
            lt.Add(new LatexText("UnderLine text", LatexText.TEXT_UNDERLINE));

            lt.Font = "cmss";

            LatexImage img2 = new LatexImage(@"C:\Users\Matteo\Desktop\Giugno 2017\sfondo1.jpg");
            lt.Add(img2);
            lt.Add(new LatexParagraph("Change Font: Computer Modern Sans Serif", LoremIpsum));

            lt.Font = LatexDocument.Document.DEFAULT_FONT;

            lt.NewPage();
            lt.Add(new LatexTextTitle("Formulas", LatexTextTitle.Huge));
            lt.AddMath(@"\lim_{x \to \infty} \exp(-x) = 0");
            lt.NewLine();
            lt.AddMath(@"\frac{n!}{k!(n-k)!} = \binom{n}{k}");
            lt.NewLine();
            lt.AddMath(@"\cos (2\theta) = \cos^2 \theta - \sin^2 \theta");

            lt.NewLine(); lt.NewLine();
            lt.Add(new LatexTextTitle("Table", LatexTextTitle.Huge));
            lt.NewLine();
            string[,] elements = new string[3, 3];

            elements[0, 0] = "Pizza";
            elements[0, 1] = "Pane";
            elements[0, 2] = "Spaghetti";

            elements[1, 0] = "1";
            elements[1, 1] = "2";
            elements[1, 2] = "3";

            elements[2, 0] = "4";
            elements[2, 1] = "5";
            elements[2, 2] = "6";

            lt.Add(new LatexTable(elements));

            lt.Add(new LatexParagraph(LoremIpsum));

            lt.NewLine(); lt.NewLine();
            lt.Add(new LatexTextTitle("Table (no borders) Wrapped", LatexTextTitle.Huge));

            lt.Add(new LatexTable(elements, false, true));
            lt.Add(new LatexParagraph(LoremIpsum));
            lt.NewPage();

            lt.Add(new LatexTextTitle("Bullet List", LatexTextTitle.Huge));

            List<string> items = new List<string>();
            items.Add("Pizza");
            items.Add("Pane");
            items.Add("Pasta");
            items.Add("Spaghetti");

            lt.Add(new LatexList(LatexList.BULLET, items));

            lt.Add(new LatexTextTitle("Enumerate List", LatexTextTitle.Huge));

            lt.Add(new LatexList(LatexList.ENUMERATE, items));

            lt.Add(new LatexTextTitle("Descriptive List", LatexTextTitle.Huge));

            Dictionary<string, string> desc = new Dictionary<string, string>();
            desc.Add("Pizza", LoremIpsum.Substring(0, 175));
            desc.Add("Pane", LoremIpsum.Substring(0, 175));
            desc.Add("Pasta", LoremIpsum.Substring(0, 175));
            desc.Add("Spaghetti", LoremIpsum.Substring(0, 175));

            lt.Add(new LatexList(desc));
            lt.NewPage();

            lt.Add(new LatexText(LoremIpsum.Substring(0, 275)));
            lt.NewLine();

            lt.Add(new LatexTextTitle("Pie Graph", LatexTextTitle.LARGE));
            lt.NewLine();
            List<LatexGraphValue> datas = new List<LatexGraphValue>();
            datas.Add(new LatexGraphValue(10, "Pizza", "red"));
            datas.Add(new LatexGraphValue(20, "Pane", "green"));
            datas.Add(new LatexGraphValue(30, "Pasta", "blue"));
            datas.Add(new LatexGraphValue(40, "Spaghetti", "orange"));

            LatexPieGraph graph = new LatexPieGraph(datas);
            lt.Add(graph);

            lt.Add(new LatexTextTitle("Bar Graph", LatexTextTitle.LARGE));
            lt.NewLine();

            LatexBarGraph graph2 = new LatexBarGraph(datas);
            lt.Add(graph2);

            TextArea.Text = lt.ToString();
        }

        #region Numbers, Bookmarks, Code Folding

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0xB7B7B7;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0x2A211C;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        #endregion

        private void InitNumberMargin()
        {

            TextArea.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            TextArea.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = TextArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            lt.RecreateDocument(TextArea.Text);
        }

    }
}
