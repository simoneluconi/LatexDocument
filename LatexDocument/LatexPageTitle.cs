namespace LatexDocument
{
    public class LatexPageTitle
    {
        /// <summary>
        /// Text to be displayed in the title page
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Date to be displayed in the title page
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Author to be displayed in the title page
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Instantiates a new LatexPageTitle object
        /// </summary>
        /// <param name="Title">Text to be displayed in the title page</param>
        public LatexPageTitle(string Title)
        {
            this.Title = Title;
        }

        /// <summary>
        /// Instantiates a new LatexPageTitle object
        /// </summary>
        /// <param name="Title">Text to be displayed in the title page</param>
        /// <param name="Author">Author to be displayed in the title page</param>
        public LatexPageTitle(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
        }

        /// <summary>
        /// Instantiates a new LatexPageTitle object
        /// </summary>
        /// <param name="Title">Text to be displayed in the title page</param>
        /// <param name="Author">Author to be displayed in the title page</param>
        /// <param name="Date">Date to be displayed in the title page</param>
        public LatexPageTitle(string Title, string Author, string Date)
        {
            this.Title = Title;
            this.Author = Author;
            this.Date = Date;
        }

    }
}
