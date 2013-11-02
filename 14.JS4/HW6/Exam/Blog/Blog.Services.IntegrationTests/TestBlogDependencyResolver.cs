using Blog.Services.Controllers;
using Blog.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;

namespace Blog.Services.IntegrationTests
{
    class TestStudentsDependencyResolver : IDependencyResolver
    {
        private AllRepositories allRepositories;

        public AllRepositories Repository
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
