using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbSchoolRepository : IRepository<School>
    {
        private DbContext dbContext;
        private DbSet<School> entitySet;

        public DbSchoolRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = dbContext.Set<School>();
        }

        public School Add(School entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public School Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<School> All()
        {
            return this.entitySet;
        }
    }
}
