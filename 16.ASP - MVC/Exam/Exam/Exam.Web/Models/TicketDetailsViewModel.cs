using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketDetailsViewModel
    {
        static public Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel
                {
                    TicketId = ticket.TicketId,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    AuthorName = ticket.Author.UserName,
                    ScreenShotURL = ticket.ScreenShotURL,
                    CategoryName = ticket.Category.Name,
                    Comments = ticket.Comments.Select(comment => new CommentViewModel { Content = comment.Content, UserName = comment.User.UserName }),
                };
            }
        }

        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public string AuthorName { get; set; }

        public string ScreenShotURL { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}