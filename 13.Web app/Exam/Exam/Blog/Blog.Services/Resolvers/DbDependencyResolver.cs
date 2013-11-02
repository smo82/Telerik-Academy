using Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Blog.Services.Controllers;
using Blog.Services.Repositories;
using System.Data.Entity;

namespace Blog.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static AllRepositories allRepositories = new AllRepositories(new BlogEntities());

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(allRepositories);
            }
            else if (serviceType == typeof(PostsController))
            {
                return new PostsController(allRepositories);
            }
            else if (serviceType == typeof(TagsController))
            {
                return new TagsController(allRepositories);
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