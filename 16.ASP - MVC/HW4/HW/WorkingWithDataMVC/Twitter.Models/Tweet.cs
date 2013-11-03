using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Models
{
    [Table("Tweets")]
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public virtual UserProfile User { get; set; }

        public virtual HashSet<Tag> Tags { get; set; }
    }
}
