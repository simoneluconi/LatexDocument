using System.Collections.Generic;

namespace LatexDocument
{
    public class LatexColumns
    {

        private List<object> objects = new List<object>();

        /// <summary>
        /// Instantiates a new LatexColumns object
        /// </summary>
        /// <param name="Objects">Objects to be added in each column</param>
        public LatexColumns(params object[] Objects)
        {
            objects.AddRange(Objects);
        }
        
        /// <summary>
        /// Objects in the columns
        /// </summary>
        public List<object> Objects 
        {
           get
           {
                return objects;
           }
        }

    }
}
