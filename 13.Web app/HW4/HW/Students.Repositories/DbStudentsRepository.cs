using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbStudentsRepository : IRepository<Student>
    {
        private DbContext dbContext;
        private DbSet<Student> entitySet;

        public DbStudentsRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Student>();
        }

        public Student Add(Student entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Student Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Student> All()
        {
            return this.entitySet;
        }
    }
}
