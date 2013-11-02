using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbMarksRepository : IRepository<Mark>
    {
        private DbContext dbContext;
        private DbSet<Mark> entitySet;

        public DbMarksRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Mark>();
        }

        public Mark Add(Mark entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Mark Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Mark> All()
        {
            return this.entitySet;
        }
    }
}
