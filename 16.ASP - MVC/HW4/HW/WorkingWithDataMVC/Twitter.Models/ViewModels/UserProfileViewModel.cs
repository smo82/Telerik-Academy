using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models.ViewModels
{
    public class UserProfileViewModel
    {
        static public Expression<Func<UserProfile, UserProfileViewModel>> FromUserProfile
        {
            get
            {
                return userProfile => new UserProfileViewModel
                {
                    UserId = userProfile.UserId,
                    UserName = userProfile.UserName,
                    Tweets = userProfile.Tweets.Select(tweet => tweet.TweetId)
                };
            }
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<int> Tweets { get; set; }
    }
}
