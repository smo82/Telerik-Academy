using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineBanking.WebApi.Models
{
    [DataContract]
    public class AccountModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "owner")]
        public string OwnerName { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }
    }
}