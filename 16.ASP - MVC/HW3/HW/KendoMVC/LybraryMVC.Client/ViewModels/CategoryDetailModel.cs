using LibraryMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LybraryMVC.Client.ViewModels
{
    public class CategoryDetailModel
    {
        public static Expression<Func<Category, CategoryDetailModel>> FromCategory
        {
            get
            {
                return category => new CategoryDetailModel
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
            }
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}