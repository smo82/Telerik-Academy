using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Services.Models
{
    public class ModelFunctions
    {
        public static IQueryable<PostDetailModel> GetPostsDetails(IQueryable<Post> posts)
        {
            var postsModels =
                (from post in posts
                 select new PostDetailModel()
                 {
                     Id = post.PostId,
                     Title = post.Title,
                     PostedBy = post.User.DisplayName,
                     PostDate = post.PostDate,
                     Text = post.Content,
                     Tags = (from tag in post.Tags
                             select tag.Name),
                     Comments = (from comment in post.Comments
                                 select new CommentModel()
                                 {
                                     Text = comment.Content,
                                     CommentedBy = comment.User.DisplayName,
                                     PostDate = comment.CommentDate
                                 }
                     )
                 }
                );

            return postsModels;
        }

        public static PostDetailModel GetSinglePostDetails(Post post)
        {
            PostDetailModel postDetails = new PostDetailModel
            {
                Id = post.PostId,
                Title = post.Title,
                PostedBy = post.User.DisplayName,
                PostDate = post.PostDate,
                Text = post.Content,
                Tags = (from tag in post.Tags
                        select tag.Name),
                Comments = (from comment in post.Comments
                            select new CommentModel()
                            {
                                Text = comment.Content,
                                CommentedBy = comment.User.DisplayName,
                                PostDate = comment.CommentDate
                            }
                )
            };

            return postDetails;
        }
    }
}