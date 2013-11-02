using CodeJewels.DataModel;
using CodeJewels.Service.Controllers;
using CodeJewels.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace CodeJewels.Service.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext codeJewelsContext = new CodeJewesDbEntities();

        private static DbAllRepositories dbAllRepositories = new DbAllRepositories(codeJewelsContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CodeJewelsController))
            {
                return new CodeJewelsController(dbAllRepositories);
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