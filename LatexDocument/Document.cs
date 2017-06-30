using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.IO;
using System.Text;

namespace LatexDocument
{
    public class Document
    {
        private string FILE_FOLDER;
        private string IMAGE_FOLDER;
        private string LATEX_EXECUTABLE;
        private string _font;

        private LatexDocumentMargins Margins;
        private List<string> LatexPackages;

        StringBuilder sb;

        /// <summary>
        /// Create a new LaTeX Document
        /// </summary>
        /// <param name="LaTeXExecutable">Path to the LaTeX Compiler Executable</param>
        /// <param name="FolderName">Path to the folder to work with</param>
        /// <param name="Margin">Document Margin in in</param>
        /// <param name="LatexPackages">Packages to be added in the document</param>

        public Document(string LaTeXExecutable, string FolderName)
        {
            Init(LaTeXExecutable, FolderName, new LatexDocumentMargins(), new List<string>());
        }

        public Document(string LaTeXExecutable, string FolderName, LatexDocumentMargins Margins)
        {
            Init(LaTeXExecutable, FolderName, Margins, new List<string>());
        }

        public Document(string LaTeXExecutable, string FolderName, List<string> LatexPackages)
        {
            Init(LaTeXExecutable, FolderName, new LatexDocumentMargins(), LatexPackages);
        }

        public Document(string LaTeXExecutable, string FolderName, LatexDocumentMargins Margins, List<string> LatexPackages)
        {
            Init(LaTeXExecutable, FolderName, new LatexDocumentMargins(), LatexPackages);
        }

        /// <summary>
        /// Inizialize the LaTeX Document
        /// </summary>
        /// <param name="LaTeXExecutable">Path to the LaTeX Compiler Executable</param>
        /// <param name="FileFolder">Path to the folder to work with</param>
        /// <param name="Margins">Document Margin in inch</param>
        /// <param name="LatexPackages">Packages to be added in the document</param>
        private void Init(string LaTeXExecutable, string FileFolder, LatexDocumentMargins Margins, List<string> LatexPackages)
        {
            if (FileFolder.Contains(" "))
                throw new Exception("File folder path can't cointains space!");

            this.LatexPackages = new List<string>();
            this.LatexPackages.AddRange(LatexPackages);

            if (!Directory.Exists(FileFolder)) Directory.CreateDirectory(FileFolder);
            if (!File.Exists(LaTeXExecutable))
                throw new Exception("The LaTeX executable doesen't exist!");
            if (!LaTeXExecutable.EndsWith(".exe"))
                throw new Exception("The selected LaTeX executable is not an executable!");

            LATEX_EXECUTABLE = LaTeXExecutable;
            FILE_FOLDER = FileFolder;
            IMAGE_FOLDER = Path.Combine(FILE_FOLDER, @"images\");
            this.Margins = Margins;
            if (!Directory.Exists(IMAGE_FOLDER)) Directory.CreateDirectory(IMAGE_FOLDER);

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            sb = new StringBuilder();
            sb.AppendLine(@"\documentclass{article}");
            sb.AppendLine(@"\usepackage[utf8]{inputenc}");
            sb.AppendLine(@"\usepackage{graphicx}");
            sb.AppendLine(string.Format(@"\graphicspath{{{0}}}", "{" + IMAGE_FOLDER.Replace("\\", "/") + "}"));
            sb.AppendLine(@"\usepackage{multicol}");
            sb.AppendLine(@"\usepackage{pgf-pie}");
            sb.AppendLine(@"\usepackage{pgfplots}");
            sb.AppendLine(@"\usepackage{tikz}");
            sb.AppendLine(@"\usepackage{wrapfig}");
            sb.AppendLine(@"\usepackage{mathtools}");
            sb.AppendLine(@"\usepackage{color}");
            sb.AppendLine(@"\pgfplotsset{compat=1.15}");
            sb.AppendLine(@"\usepackage{lipsum}");
            sb.AppendLine(string.Format(@"\usepackage[tmargin={0}in,bmargin={1}in,lmargin={2}in,rmargin={3}in]", Margins.Top, Margins.Bottom, Margins.Right, Margins.Left) + @"{geometry}");

            foreach (string package in LatexPackages)
            {
                sb.AppendLine(string.Format(@"\usepackage{{{0}}}", package));
            }

            sb.AppendLine(@"\begin{document}");
        }

        /// <summary>
        /// Document font
        /// </summary>
        public string Font
        {
            get
            {
                return _font;
            }

            set
            {
                if (value != null)
                {
                    _font = value;
                    sb.AppendLine(string.Format(@"\fontfamily{{{0}}}", value));
                    sb.AppendLine(@"\selectfont");
                }
                else
                {
                    _font = LatexFont.DEFAULT_FONT;
                    sb.AppendLine(string.Format(@"\fontfamily{{{0}}}", _font));
                    sb.AppendLine(@"\selectfont");
                }
            }
        }

        /// <summary>
        /// Start a container with the center align
        /// </summary>
        public void StartCenterAlign()
        {
            sb.AppendLine(@"\begin{center}");
        }

        /// <summary>
        /// End a container for the align
        /// </summary>
        public void EndAlign()
        {
            sb.AppendLine(@"\end{center}");
        }

        /// <summary>
        /// Add a LatexPageTitle object in the document
        /// </summary>
        /// <param name="Title">LatexPageTitle object to be added in the document</param>
        /// <param name="CreateNewPage">Add the title in a new page</param>
        public void Add(LatexPageTitle Title, bool CreateNewPage = true)
        {
            sb.AppendLine(string.Format(@"\title{{{0}}}", Title.Title));

            if (Title.Date != null)
                sb.AppendLine(string.Format(@"\date{{{0}}}", Title.Date));

            if (Title.Author != null)
                sb.AppendLine(string.Format(@"\author{{{0}}}", Title.Author));

            sb.AppendLine(@"\maketitle");

            if (CreateNewPage)
                NewPage();
        }

        /// <summary>
        /// Add a LatexText object in the document
        /// </summary>
        /// <param name="text">LatexText object to be added in the document</param>
        public void Add(LatexText text)
        {
            if (text.Font.Color == null && text.Font.Type == null)
            {
                sb.AppendLine(text.Text);
            }
            else if (text.Font.Type != null && text.Font.Color == null)
            {
                sb.AppendLine(string.Format(text.Font.Type, text.Text));
            }
            else if (text.Font.Type == null && text.Font.Color != null)
            {
                sb.AppendLine(string.Format(@"\textcolor{{{0}}}{{{1}}}", text.Font.Color, text.Text));
            }
            else if (text.Font.Type != null && text.Font.Color != null)
            {
                sb.AppendLine(string.Format(@"\textcolor{{{0}}}{{{1}}}", text.Font.Color, string.Format(text.Font.Type, text.Text)));
            }
            else throw new Exception("Can't establish formatting");
        }

        /// <summary>
        /// Add a LatexParagraph object in the document
        /// </summary>
        /// <param name="Paragraph">LatexParagraph object to be added in the document</param>
        public void Add(LatexParagraph Paragraph)
        {
            sb.AppendLine(string.Format(@"\paragraph{{{0}}}", Paragraph.Heading));
            if (Paragraph.Font.Color == null)
                sb.AppendLine(Paragraph.Text);
            else Add(new LatexText(Paragraph.Text, Paragraph.Font));
        }

        /// <summary>
        /// Add a LatexList object in the document
        /// </summary>
        /// <param name="List">LatexList object to be added in the document</param>
        public void Add(LatexList List)
        {
            sb.AppendLine(string.Format(@"\begin{{{0}}}", List.Type));

            if (List.DescriptiveList == null)
            {
                foreach (var item in List.Items)
                {
                    sb.AppendLine(string.Format(@"\item {0}", item));
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> entry in List.DescriptiveList)
                {
                    sb.AppendLine(string.Format(@"\item[{0}] {1}", entry.Key, entry.Value));
                }
            }

            sb.AppendLine(string.Format(@"\end{{{0}}}", List.Type));
        }

        /// <summary>
        /// Add a LatexImage object in the document
        /// </summary>
        /// <param name="Image">LatexImage object to be added in the document</param>
        public void Add(LatexImage Image)
        {
            string FileName = Path.GetFileName(Image.Path);
            string NewPath = Path.Combine(IMAGE_FOLDER, FileName);
            if (File.Exists(NewPath))
                File.Delete(NewPath);
            File.Copy(Image.Path, NewPath);
            string FileNameNoExt = Path.GetFileNameWithoutExtension(Image.Path);

            sb.AppendLine(@"\begin{wrapfigure}{R}{0.3\textwidth}");
            sb.AppendLine(@"\centering");
            sb.AppendLine(@"\includegraphics[width=0.25\textwidth]{" + FileNameNoExt + "}");

            if (Image.Caption != null)
                sb.AppendLine(@"\caption{\label{fig:" + FileNameNoExt + "}" + Image.Caption + "}");

            sb.AppendLine(@"\end{wrapfigure}");
        }

        /// <summary>
        /// Add a LatexTextTitle object in the document
        /// </summary>
        /// <param name="Title">LatexTextTitle object to be added in the document</param>
        public void Add(LatexTextTitle Title)
        {
            if (Title.Font.Size == null && Title.Font.Color == null)
            {
                Add(new LatexText(Title.Text));
            }
            else if (Title.Font.Size == null && Title.Font.Color != null)
            {
                Add(new LatexText(Title.Text, Title.Font));
            }
            else if (Title.Font.Size != null && Title.Font.Color == null)
            {
                sb.AppendLine(@"{" + Title.Font.Size + " " + Title.Text + "}");
            }
            else if (Title.Font.Size != null && Title.Font.Color != null)
            {
                sb.AppendLine(string.Format(@"\textcolor{{{0}}}{{{1}}}", Title.Font.Color, @"{" + Title.Font.Size + " " + Title.Text + "}"));
            }
            else throw new Exception("Can't establish formatting");

            NewLine();
        }

        /// <summary>
        /// Add a LatexColumns object in the document
        /// </summary>
        /// <param name="Columns">LatexColumns object to be added in the document</param>
        public void Add(LatexColumns Columns)
        {
            List<object> objects = Columns.Objects;

            sb.AppendLine(@"\begin{multicols}{" + objects.Count + "}");
            foreach (object obj in objects)
            {
                Add(obj);
                sb.AppendLine(@"\columnbreak");
            }
            sb.AppendLine(@"\end{multicols}");
        }

        /// <summary>
        /// Add a LatexTable object in the document
        /// </summary>
        /// <param name="Table">LatexTable object to be added in the document</param>
        public void Add(LatexTable Table)
        {
            if (Table.Wrap)
            {
                sb.AppendLine(@"\begin{wrapfigure}{R}{0.3\textwidth}");
                sb.AppendLine(@"\centering");
            }

            sb.Append(@"\begin{tabular}");

            if (Table.Borders)
            {
                sb.AppendLine(@"{ | l | c | r | }");
                sb.AppendLine(@"\hline");
            }
            else sb.AppendLine(@"{ l c r }");

            for (int i = 0; i < Table.Elements.GetLength(0); i++)
            {

                string[] rows = new string[Table.Elements.GetLength(1)];
                for (int j = 0; j < Table.Elements.GetLength(1); j++)
                {
                    rows[j] = Table.Elements[i, j];
                }

                sb.AppendLine(string.Format("{0} \\\\ {1}", string.Join(" & ", rows), Table.Borders ? @"\hline" : ""));
            }

            sb.AppendLine(@"\end{tabular}");

            if (Table.Wrap)
                sb.AppendLine(@"\end{wrapfigure}");
        }

        /// <summary>
        /// Add a LatexPieGraph object in the document
        /// </summary>
        /// <param name="Graph">LatexPieGraph object to be added in the document</param>
        public void Add(LatexPieGraph Graph)
        {
            if (Graph.Centered)
                StartCenterAlign();

            sb.AppendLine(@"\begin{tikzpicture}");

            int Total = 0;

            foreach (var item in Graph.Values)
            {
                Total += item.Value;
            }

            List<string> values = new List<string>();
            List<string> colors = new List<string>();

            foreach (var item in Graph.Values)
            {
                int p = (100 * item.Value) / Total;
                values.Add(string.Format("{0}/{1}", p, item.Label));
                if (item.Color != null) colors.Add(item.Color);
            }

            string datas = string.Join(",", values);

            if (colors.Count > 0)
            {
                sb.AppendLine(@"\pie[color={" + string.Join(",", colors) + "}]{" + datas + "}");
            }
            else
                sb.AppendLine(@"\pie{" + datas + "}");
            sb.AppendLine(@"\end{tikzpicture}");

            if (Graph.Centered)
                EndAlign();
        }

        /// <summary>
        /// Add a LatexBarGraph object in the document
        /// </summary>
        /// <param name="Graph">LatexBarGraph object to be added in the document</param>
        public void Add(LatexBarGraph Graph)
        {
            if (Graph.Centered)
                StartCenterAlign();

            sb.AppendLine(@"\begin{tikzpicture}");
            sb.AppendLine(@"\begin{axis}[");
            sb.AppendLine(@"symbolic x coords={");

            List<string> AxisLabels = new List<string>();
            foreach (LatexGraphValue item in Graph.Values)
            {
                AxisLabels.Add(item.Label);
            }

            sb.Append(string.Join(",", AxisLabels));
            sb.AppendLine(@"},");
            sb.AppendLine(@"xtick=data]");
            sb.AppendLine(@"\addplot[ybar,fill= " + Graph.BarColor + "] coordinates {");
            foreach (LatexGraphValue item in Graph.Values)
            {
                sb.AppendLine(string.Format("({0},{1})", item.Label, item.Value));
            }
            sb.AppendLine(@"};");
            sb.AppendLine(@"\end{axis}");
            sb.AppendLine(@"\end{tikzpicture}");

            if (Graph.Centered)
                EndAlign();
        }

        /// <summary>
        /// Add a LatexPlotGraph object in the document
        /// </summary>
        /// <param name="Graph">LatexPlotGraph object to be added in the document</param>
        public void Add(LatexPlotGraph Graph)
        {
            if (Graph.Centered)
                StartCenterAlign();

            sb.AppendLine(@"\begin{tikzpicture}");
            sb.AppendLine(@"\begin{axis}[");
            if (Graph.Title != null)
                sb.AppendLine(string.Format(@"title={{{0}}},", Graph.Title));
            if (Graph.XLabel != null)
                sb.AppendLine(string.Format(@"xlabel={{{0}}},", Graph.XLabel));
            if (Graph.YLabel != null)
                sb.AppendLine(string.Format(@"ylabel={{{0}}},", Graph.YLabel));
            if (Graph.XMin != 0 || Graph.XMax != 0)
                sb.AppendLine(string.Format(@"xmin={0}, xmax={1},", Graph.XMin, Graph.XMax));
            if (Graph.YMin != 0 || Graph.YMax != 0)
                sb.AppendLine(string.Format(@"ymin={0}, ymax={1},", Graph.YMin, Graph.YMax));
            if (Graph.XTick != null)
                sb.AppendLine(string.Format(@"xtick={{{0}}},", string.Join(",", Graph.XTick)));
            if (Graph.YTick != null)
                sb.AppendLine(string.Format(@"ytick={{{0}}},", string.Join(",", Graph.YTick)));
            if (Graph.LegendPosition != null)
                sb.AppendLine(string.Format(@"legend pos={0},", Graph.LegendPosition));
            sb.AppendLine(string.Format(@"ymajorgrids = {0},", Graph.YMajorGrids.ToString().ToLower()));
            sb.AppendLine(string.Format(@"xmajorgrids = {0},", Graph.XMajorGrids.ToString().ToLower()));
            if (Graph.GridStyle != null)
                sb.AppendLine(string.Format(@"grid style = {0}", Graph.GridStyle));
            sb.AppendLine("]");

            foreach (LatexPlot plot in Graph.Plots)
            {
                sb.AppendLine(@"\addplot[");
                if (plot.LineColor != null)
                    sb.AppendLine(string.Format(@"color = {0},", plot.LineColor));
                if (plot.MarksStyle != null)
                    sb.AppendLine(string.Format(@"mark = {0},", plot.MarksStyle));
                sb.AppendLine("]");

                if (plot.Coordinates != null)
                {
                    sb.AppendLine(@"coordinates {");

                    foreach (Point p in plot.Coordinates)
                    {
                        sb.AppendFormat("({0},{1})", p.X, p.Y);
                    }

                    sb.AppendLine();
                    sb.AppendLine("};");
                }
                else if (plot.Expression != null)
                {
                    sb.AppendLine(string.Format(@"{{{0}}};", plot.Expression));
                }
                sb.AppendLine(string.Format(@"\addlegendentry{{{0}}}", plot.Legend));
            }

            sb.AppendLine(@"\end{axis}");
            sb.AppendLine(@"\end{tikzpicture}");

            if (Graph.Centered)
                EndAlign();
        }

        /// <summary>
        /// Escape the Math with $
        /// </summary>
        /// <param name="Text">Math Syntax</param>
        public void AddMath(string Text)
        {
            AddRawText("$" + Text + "$");
        }

        /// <summary>
        /// Add Raw Text in the document
        /// </summary>
        /// <param name="Text">Text to append in the document</param>
        public void AddRawText(string Text)
        {
            sb.AppendLine(Text);
        }

        /// <summary>
        /// Create a new line
        /// </summary>
        public void NewLine()
        {
            sb.AppendLine(@"\newline");
        }

        /// <summary>
        /// Create a new page
        /// </summary>
        public void NewPage()
        {
            sb.AppendLine(@"\newpage");
        }

        /// <summary>
        /// Fill the page
        /// </summary>
        public void Fill()
        {
            sb.AppendLine(@"\vfill");
        }

        /// <summary>
        /// Create Tex output
        /// </summary>
        public void CreateLatex()
        {
            CreateLatex(string.Format("{0}", DateTime.Now.ToString("yyMMdd-hhmmss")));
        }

        /// <summary>
        /// Create Tex Output
        /// </summary>
        /// <param name="FileName">Output file name without extension</param>
        public void CreateLatex(string FileName)
        {
            EndDocument();

            string FilePath = Path.Combine(FILE_FOLDER, string.Format("{0}.tex", FileName));
            StreamWriter sw = new StreamWriter(FilePath);
            sw.Write(sb.ToString());
            sw.Close();
        }

        /// <summary>
        /// Create PDF output
        /// </summary>
        public void CreatePdf()
        {
            CreatePdf(string.Format("{0}", DateTime.Now.ToString("yyMMdd-hhmmss")));
        }

        /// <summary>
        /// Create PDF output
        /// </summary>
        /// <param name="FileName">Output file name without extension</param>
        public void CreatePdf(string FileName, bool OpenAfterCompile = false)
        {
            string FilePath = Path.Combine(FILE_FOLDER, string.Format("{0}.tex", FileName));
            CreateLatex(FileName);

            Process p = Process.Start(LATEX_EXECUTABLE, string.Format("-aux-directory={0} -output-directory={1} {2}", FILE_FOLDER, FILE_FOLDER, FilePath));
            p.WaitForExit();

            Debug.WriteLine("Compiler Exit Code: " + p.ExitCode);

            if (p.ExitCode == 0 && OpenAfterCompile)
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine(FILE_FOLDER, string.Format("{0}.pdf", FileName))));
        }

        /// <summary>
        /// End the document
        /// </summary>
        private void EndDocument()
        {
            sb.AppendLine(@"\end{document}");
        }

        /// <summary>
        /// Clear the document and insert the new text in it.
        /// </summary>
        /// <param name="Text">Text to be added in the document</param>
        public void RecreateDocument(string Text)
        {
            sb = new StringBuilder();
            sb.Append(Text);
        }

        /// <summary>
        /// Reinizialize the LaTeX document 
        /// </summary>
        public void RecreateDocument()
        {
            Init(LATEX_EXECUTABLE, IMAGE_FOLDER, Margins, LatexPackages);
        }

        private void Add(object obj)
        {
            if (obj is LatexText)
                Add(obj as LatexText);

            else if (obj is LatexImage)
                Add(obj as LatexImage);

            else if (obj is LatexPieGraph)
                Add(obj as LatexPieGraph);

            else if (obj is LatexBarGraph)
                Add(obj as LatexBarGraph);

            else if (obj is LatexParagraph)
                Add(obj as LatexParagraph);

            else if (obj is LatexParagraph)
                Add(obj as LatexParagraph);

            else if (obj is LatexTable)
                Add(obj as LatexTable);

            else if (obj is LatexPlotGraph)
                Add(obj as LatexPlotGraph);

            else throw new ArgumentException("Can't add non-Latex object. (" + obj.GetType().Name + ")");
        }

        /// <summary>
        /// Get the document raw text
        /// </summary>
        /// <returns>Document raw text</returns>
        public override string ToString()
        {
            return sb.ToString() + @"\end{document}";
        }
    }
}
