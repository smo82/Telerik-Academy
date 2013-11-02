using Forum.Data;
using Forum.Services.Models;
using Forum.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        private AllRepositories data;

        public TagsController()
        {
            data = new AllRepositories(new ForumDbEntities());
        }

        public TagsController(AllRepositories data)
        {
            this.data = data;
        }

        public IQueryable<TagModel> Get(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  IRepository<Tag> tagRepository = this.data.GetTagsRepository();

                  IQueryable<Tag> tags = tagRepository.All();

                  var tagModels =
                      (from tag in tags
                       select new TagModel()
                       {
                           Id = tag.TagId,
                           Name = tag.Name,
                           Posts = tag.Posts.Count()
                       }
                      );

                  // I sort the tags by name because that is how Toshoko said we should do it
                  return tagModels.OrderBy(t => t.Name);
              });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<PostDetailModel> GetPosts(string sessionKey, int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  IRepository<Tag> tagRepository = this.data.GetTagsRepository();

                  Tag tag = tagRepository.Get(id);

                  if (tag == null)
                  {
                      throw new InvalidOperationException("No such tag");
                  }

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  IQueryable<Post> posts = postRepository.GetConstraint(p => p.Tags.Any(t => t.TagId == id));

                  IQueryable<PostDetailModel> postsModels = ModelFunctions.GetPostsDetails(posts);

                  return postsModels.OrderByDescending(p => p.PostDate);
              });

            return responseMsg;
        }

        private User VerifySessionKey(string sessionKey)
        {
            IRepository<User> userRepository = this.data.GetUserRepository();

            IQueryable<User> usersFound = userRepository.GetConstraint(usr => usr.SessionKey == sessionKey);

            if (usersFound.Count() == 0)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            return usersFound.First();
        }
    }
}
