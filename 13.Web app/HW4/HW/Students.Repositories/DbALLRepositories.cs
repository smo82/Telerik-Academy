using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public class DbAllRepositories
    {
        private DbContext dbContext;

        public DbAllRepositories(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSchoolRepository GetSchoolRepository()
        {
            return new DbSchoolRepository(this.dbContext);
        }

        public DbStudentsRepository GetStudentsRepository()
        {
            return new DbStudentsRepository(this.dbContext);
        }

        public DbMarksRepository GetMarksRepository()
        {
            return new DbMarksRepository(this.dbContext);
        }
    }
}
