using System;

using Xamarin.Forms;

namespace TwitterXamApp
{
	public class App : Application
	{
		public static User UserInfo;

		public App ()
		{
			// The root page of your application
			if(App.UserInfo==null){
				MainPage = new LoginPage ();
			}else{
				MainPage = new MyFeedPage ();
			}
		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
					{
						App.Current.MainPage = new NavigationPage(new MyFeedPage());
					});
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

