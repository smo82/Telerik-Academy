using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
