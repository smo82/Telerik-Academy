using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models.ViewModels
{
    public class TweetViewModel
    {
        static public Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel
                {
                    TweetId = tweet.TweetId,
                    Content = tweet.Content,
                    Tags = tweet.Tags.Select(tag => tag.TagId),
                    UserId = tweet.User.UserId
                };
            }
        }

        public int TweetId { get; set; }

        public string Content { get; set; }

        public IEnumerable<int> Tags { get; set; }

        public int UserId { get; set; }
    }
}
