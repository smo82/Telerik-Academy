
using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class CategoryViewModel
    {
        static public Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
            }
        }

        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}