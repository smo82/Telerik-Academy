using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketViewModel
    {
        static public Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    TicketId = ticket.TicketId,
                    Title = ticket.Title,
                    CategoryName = ticket.Category.Name,
                    AuthorName = ticket.Author.UserName,
                    NumberOfComments = ticket.Comments.Count(),
                    Priority = ticket.Priority
                };
            }
        }

        public int TicketId { get; set; }
        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int NumberOfComments { get; set; }

        public Priority Priority { get; set; }

        public string PriorityAsString
        {
            get
            {
                return this.Priority.ToString();
            }
        }
    }
}