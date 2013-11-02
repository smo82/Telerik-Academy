﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract(Name = "Tag")]
    public class TagModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "webapi")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int Posts { get; set; }
    }
}