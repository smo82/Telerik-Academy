using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("SearchLog")]
    public class SearchLog
    {
        public SearchLog()
        {
        }

        [Key, Column("SearchLogId")]
        public int SearchLogId { get; set; }

        public string QueryXml { get; set; }

        public DateTime Date { get; set; }

    }
}
