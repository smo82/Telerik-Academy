using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Ticket
    {
        private Priority priority;
        private ICollection<Comment> comments;

        public Ticket()
        {
            this.priority = Priority.Medium;
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int TicketId { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [StringDoesntContainAttribute("Bug", ErrorMessage="The Title cannot contain the word 'bug'!")]
        public string Title { get; set; }

        [Required]
        public Priority Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }

        public string ScreenShotURL { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
