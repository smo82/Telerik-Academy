using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNewsArticles
{
    class ArticlesData
    {
        public Article[] Articles { get; set; }
        public string Description { get; set; }
        public string Syndication_url { get; set; }
        public string Title { get; set; }
    }
}
