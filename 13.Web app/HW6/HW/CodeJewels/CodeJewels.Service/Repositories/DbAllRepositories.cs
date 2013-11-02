using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeJewels.Service.Repositories
{
    public class DbAllRepositories
    {
        private DbContext dbContext;

        public DbAllRepositories(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbCodeJewelsRepository GetCodeJewelRepository()
        {
            return new DbCodeJewelsRepository(this.dbContext);
        }
    }
}