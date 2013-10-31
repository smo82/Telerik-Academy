namespace FreeContent
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> contentByUrl;
        private OrderedMultiDictionary<string, IContent> contentByTitle;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.contentByTitle = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.contentByUrl = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public int CountContentByTitle
        {
            get
            {
                return contentByTitle.KeyValuePairs.Count;
            }
        }

        public int CountContentByUrl
        {
            get
            {
                return contentByUrl.KeyValuePairs.Count;
            }
        }

        public void Add(IContent content)
        {
            this.contentByTitle.Add(content.Title, content);
            this.contentByUrl.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfElements)
        {
            IEnumerable<IContent> contentToList =
                from itemByTitle in this.contentByTitle[title]
                select itemByTitle;

            return contentToList.Take(numberOfElements);
        }
        
        public int UpdateContent(string oldUrl, string newUrl)
        {
            IContent[] contentToArray = this.contentByUrl[oldUrl].ToArray();
            this.contentByUrl.Remove(oldUrl);

            for (int i = 0; i < contentToArray.Length; i++)
            {
                IContent content = contentToArray[i];
                this.contentByTitle.Remove(content.Title, content);
            }

            for (int i = 0; i < contentToArray.Length; i++)
            {
                IContent content = contentToArray[i];
                content.Url = newUrl;
                this.contentByTitle.Add(content.Title, content);
                this.contentByUrl.Add(content.Url, content);
            }

            return contentToArray.Length;
        }
    }
}
