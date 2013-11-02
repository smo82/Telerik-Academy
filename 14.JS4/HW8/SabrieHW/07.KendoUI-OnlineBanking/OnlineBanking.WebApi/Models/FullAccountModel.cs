using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineBanking.WebApi.Models
{
    [DataContract]
    public class FullAccountModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }

        [DataMember(Name = "owner")]
        public LoggedUserModel Owner { get; set; }

        [DataMember(Name = "transactions")]
        public IEnumerable<TransactionLogModel> Transactions { get; set; }

        [DataMember(Name = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [DataMember(Name = "expiredDate")]
        public DateTime ExpireDate { get; set; }

        public FullAccountModel()
        {
            this.Transactions = new HashSet<TransactionLogModel>();
        }
    }
}