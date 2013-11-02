using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Forum.Services.Models
{
    [DataContract(Name = "Tag")]
    public class TagModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int Posts { get; set; }
    }
}