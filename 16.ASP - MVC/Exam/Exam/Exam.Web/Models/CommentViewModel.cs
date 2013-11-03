using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class CommentViewModel
    {
        static public Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    UserName = comment.User.UserName,
                    Content = comment.Content
                };
            }
        }

        public string UserName { get; set; }

        public string Content { get; set; }
    }
}