using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual HashSet<Tweet> Tweets { get; set; }
    }
}
