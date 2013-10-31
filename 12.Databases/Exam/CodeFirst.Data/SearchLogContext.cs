using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.Models;

namespace CodeFirst.Data
{
    public class SearchLogContext : DbContext
    {
        public SearchLogContext()
            : base("Log")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchLog>().HasKey(x => x.SearchLogId);
            modelBuilder.Entity<SearchLog>().Property(x => x.QueryXml).IsUnicode(true);
            modelBuilder.Entity<SearchLog>().Property(x => x.QueryXml).HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}
