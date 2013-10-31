// -----------------------------------------------------------------------
// <copyright file="ContentItem.cs" company="">
// Telerik
// </copyright>
// -----------------------------------------------------------------------

namespace FreeContent
{
    using System;

    public class ContentItem : IComparable, IContent
    {
        private string url;

        public ContentItem(ItemType type, string[] commandParams)
        {
            if (commandParams.Length != 4)
            {
                throw new InvalidOperationException(string.Format("Invalid number of parameters: {0}", commandParams.Length));
            }

            this.Type = type;
            this.Title = commandParams[(int)CommandParams.Title];
            this.Author = commandParams[(int)CommandParams.Author];
            this.Size = long.Parse(commandParams[(int)CommandParams.Size]);
            this.Url = commandParams[(int)CommandParams.Url];
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ItemType Type { get; set; }

        public string TextRepresentation { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public int CompareTo(object obj)
        {
            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);

            return output;
        }
    }
}
