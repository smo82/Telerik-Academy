using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
