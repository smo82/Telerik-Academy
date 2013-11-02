using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract(Name = "Comment")]
    public class CommentSimpleModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}