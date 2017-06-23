namespace LatexDocument
{
    public class LatexImage
    {
        /// <summary>
        /// Path to the image file
        /// </summary>
        public string Path { private set; get; }

        /// <summary>
        /// Caption of the image
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Instantiates a new LatexImage object
        /// </summary>
        /// <param name="Path">Path to the image file</param>
        public LatexImage(string Path)
        {
            this.Path = Path;
        }

        /// <summary>
        /// Instantiates a new LatexImage object
        /// </summary>
        /// <param name="Path">Path to the image file</param>
        /// <param name="Caption">Caption of the image</param>
        public LatexImage(string Path, string Caption)
        {
            this.Path = Path;
            this.Caption = Caption;
        }
        
    }
}
