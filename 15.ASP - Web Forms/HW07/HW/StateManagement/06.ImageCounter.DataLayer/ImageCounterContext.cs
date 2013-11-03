using ImageCounter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCounter.DataLayer
{
    public class ImageCounterContext : DbContext
    {
        public ImageCounterContext() : base("ImageCounterDb")
        {
        }

        public DbSet<ApplicationData> Applications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationData>().HasKey( a => a.ApplicationId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
