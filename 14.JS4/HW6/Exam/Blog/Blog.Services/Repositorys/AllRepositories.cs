using Blog.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Blog.Services.Repositories
{
    public class AllRepositories : DbContext
    {
        private DbContext context;

        public AllRepositories(DbContext context)
        {
            this.context = context;
        }

        public IRepository<User> GetUserRepository()
        {
            return new EfRepository<User>(this.context);
        }

        public IRepository<Post> GetPostsRepository()
        {
            return new EfRepository<Post>(this.context);
        }

        public IRepository<Tag> GetTagsRepository()
        {
            return new EfRepository<Tag>(this.context);
        }

        public IRepository<Comment> GetCommentsRepository()
        {
            return new EfRepository<Comment>(this.context);
        }
    }
}