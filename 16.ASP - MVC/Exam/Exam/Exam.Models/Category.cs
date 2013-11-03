using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Category
    {
        private ICollection<Ticket> ticket;

        public Category()
        {
            this.ticket = new HashSet<Ticket>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Ticket> Tickets
        {
            get { return this.ticket; }
            set { this.ticket = value; }
        }
    }
}
