using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBanking.WebApi.Models
{
    public class TransactionLogModel
    {
        public string LogText { get; set; }

        public DateTime LogDate { get; set; }

        public string UserFullName { get; set; }

        public int AccountId { get; set; }
    }
}