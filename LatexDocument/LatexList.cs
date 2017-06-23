using System.Collections.Generic;

namespace LatexDocument
{
    public class LatexList
    {
        /// <summary>
        /// Bullet type list ( • ) 
        /// </summary>
        public const string BULLET = "itemize";

        /// <summary>
        /// Enumerated type list ( n. ) 
        /// </summary>
        public const string ENUMERATE = "enumerate";

        /// <summary>
        /// Descriptive type list
        /// </summary>
        private const string DESCRIPTIVE = "description";

        /// <summary>
        /// Type of the list
        /// </summary>
        public string Type { private set; get; }

        /// <summary>
        /// Values of the descriptive list
        /// </summary>
        public Dictionary<string, string> DescriptiveList;

        /// <summary>
        /// Items of the bullet or enumerated list
        /// </summary>
        public List<string> Items;

        /// <summary>
        /// Instantiates a new LatexList object
        /// </summary>
        /// <param name="Type">Type of the list</param>
        /// <param name="Items">Items for the bullet or enumerated list</param>
        public LatexList(string Type, List<string> Items)
        {
            this.Type = Type;
            this.Items = new List<string>();
            this.Items.AddRange(Items);
        }

        /// <summary>
        /// Instantiates a new LatexList object
        /// </summary>
        /// <param name="Items">Values for the descriptive list</param>
        public LatexList(Dictionary<string, string> Items)
        {
            Type = DESCRIPTIVE;
            DescriptiveList = new Dictionary<string, string>();

            foreach (var item in Items)
                DescriptiveList.Add(item.Key, item.Value);
        }
    }
}
