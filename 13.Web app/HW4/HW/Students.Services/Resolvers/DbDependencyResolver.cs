using Students.DataLayer;
using Students.Models;
using Students.Repositories;
using Students.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Students.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext studentsContext = new StudentsContext();

        private static DbAllRepositories dbAllRepositories = new DbAllRepositories(studentsContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(dbAllRepositories);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(dbAllRepositories);
            }
            else if (serviceType == typeof(MarksController))
            {
                return new MarksController(dbAllRepositories);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}