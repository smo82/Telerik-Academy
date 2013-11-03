using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models.ViewModels
{
    public class TagViewModel
    {
        static public Expression<Func<Tag, TagViewModel>> FromTag
        {
            get
            {
                return tag => new TagViewModel
                {
                    TagId = tag.TagId,
                    Name = tag.Name
                };
            }
        }

        public int TagId { get; set; }

        public string Name { get; set; }
    }
}
