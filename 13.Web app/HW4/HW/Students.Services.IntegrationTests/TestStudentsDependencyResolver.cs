using Students.Repositories;
using Students.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;

namespace Students.Services.IntegrationTests
{
    class TestStudentsDependencyResolver : IDependencyResolver
    {
        private DbAllRepositories allRepositories;

        public DbAllRepositories Repository
        {
            get
            {
                return this.allRepositories;
            }
            set
            {
                this.allRepositories = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.allRepositories);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(this.allRepositories);
            }
            else if (serviceType == typeof(MarksController))
            {
                return new MarksController(this.allRepositories);
            }
            return null;
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
