using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Processing
{
    class Album
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public List<Song> Songs { get; set; }
    }
}
