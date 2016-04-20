using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using LinqToTwitter;
using System.Linq;

namespace TwitterXamApp
{
	public class TwitterService
	{
		private static TwitterContext GetTwitterContext()
		{
			var auth = new XAuthAuthorizer()
			{
				CredentialStore = new InMemoryCredentialStore
				{
					ConsumerKey = "rsrleZR4jRNIN0Cm7uPGxOpWy",
					ConsumerSecret = "ij1N7CcRwPtbe76RFdon8ruCJEMNVFJ4n03AKbVDMjzAFqbPqs",
					OAuthToken = App.UserInfo.Token,
					OAuthTokenSecret = App.UserInfo.TokenSecret,
					ScreenName = App.UserInfo.ScreenName,
					UserID = ulong.Parse(App.UserInfo.TwitterId)
				},
			};
			auth.AuthorizeAsync();

			var ctx = new TwitterContext(auth);
			return ctx;
		}

		public static List<Tweet> Search(string searchText = "toronto")
		{
			try
			{
				var ctx = GetTwitterContext();

				var searchResponses = (from search in ctx.Search
					where search.Type == SearchType.Search
					&& search.Query == searchText
					select search).SingleOrDefault();

				var tweets = from tweet in searchResponses.Statuses
					select new Tweet
				{
					Value = tweet.Text,
					Id = tweet.TweetIDs,
					ImageUri = tweet.User.ProfileImageUrl,
					UserName = tweet.User.ScreenNameResponse,
					Name = tweet.User.Name,
					CreatedAt = tweet.CreatedAt,
					ReTweets = tweet.RetweetCount,
					Favorite = tweet.FavoriteCount.Value
				};

				return tweets.ToList();
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return new List<Tweet>();
		}
	}
}

