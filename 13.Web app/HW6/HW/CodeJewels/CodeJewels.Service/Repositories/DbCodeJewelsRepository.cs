using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeJewels.DataModel;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace CodeJewels.Service.Repositories
{
    public class DbCodeJewelsRepository : IReporitory<CodeJewel>
    {
        private DbContext dbContext;
        private DbSet<CodeJewel> entitySet;

        public DbCodeJewelsRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<CodeJewel>();
        }

        public CodeJewel Add(CodeJewel entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public CodeJewel Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<CodeJewel> All()
        {
            return this.entitySet;
        }


        public void Delete(int id)
        {
            DbSet<CodeJewel> codeJewels = this.dbContext.Set<CodeJewel>();
            CodeJewel codeJewel = codeJewels.Find(id);
            codeJewels.Remove(codeJewel);

            this.dbContext.SaveChanges();
        }


        public void Update(int id, CodeJewel entity)
        {
            DbSet<CodeJewel> codeJewels = this.dbContext.Set<CodeJewel>();

            DbEntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                codeJewels.Attach(entity);
            }

            entry.State = EntityState.Modified;

            this.dbContext.SaveChanges();
        }
    }
}