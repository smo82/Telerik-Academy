using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Context
{
    public class OnlineBankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

        public OnlineBankContext()
            : base("OnlineBankDb")
        {

        }
    }
}
