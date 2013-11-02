using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNewsArticles
{
    class Article
    {
        public DateTime Publish_date { get; set; }
        public string Source { get; set; }
        public string Source_url { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
