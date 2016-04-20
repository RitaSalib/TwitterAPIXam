using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TwitterXamApp;
using TwitterXamApp.iOS;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace TwitterXamApp.iOS
{
	public class LoginPageRenderer:PageRenderer
	{
		bool showLogin = true;
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (showLogin && App.UserInfo == null)
			{
				//Twitter with OAuth1
				var auth = new OAuth1Authenticator(
					consumerKey: "rsrleZR4jRNIN0Cm7uPGxOpWy",
					consumerSecret: "ij1N7CcRwPtbe76RFdon8ruCJEMNVFJ4n03AKbVDMjzAFqbPqs",
					requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), 
					authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), 
					accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
					callbackUrl: new Uri("http://mobile.twitter.com")
				);

				auth.Completed += (sender, eventArgs) =>
				{
					DismissViewController(true, null);

					if (eventArgs.IsAuthenticated)
					{
						App.UserInfo = new User();
						App.UserInfo.Token = eventArgs.Account.Properties["oauth_token"];
						App.UserInfo.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
						App.UserInfo.TwitterId = eventArgs.Account.Properties["user_id"];
						App.UserInfo.Name = eventArgs.Account.Properties["screen_name"];

						//Store details for future use, 
						//so we don't have to prompt authentication screen everytime
						AccountStore.Create().Save(eventArgs.Account, "Twitter");

						App.SuccessfulLoginAction.Invoke();
					}
				};

				PresentViewController(auth.GetUI(), true, null);
			}
		}
	
	}
}

