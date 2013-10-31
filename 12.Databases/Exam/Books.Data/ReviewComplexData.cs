using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class ReviewComplexData
    {
        public DateTime? Date { get; set; }
        public string Content { get; set; }
        public Book Book { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
