using System;
using TwitterXam;
using System.Collections.Generic;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TwitterXamApp
{
	public class MyFeedPageViewModel:BaseViewModel
	{
		public MyFeedPageViewModel ()
		{
		}

		public async Task Init()
		{
			if (!IsDataLoaded) {
				List<Tweet> _tweets;
				using (UserDialogs.Instance.Loading ("Loading..")) {

					_tweets = TwitterService.Search("Toronto");

				} 
				if (_tweets != null) {
					Tweets = new ObservableCollection<Tweet> (_tweets);
					IsDataLoaded = true;
				}
				else{
					UserDialogs.Instance.Alert("check Internet Connection");
				}


			}
		}

		public ObservableCollection<Tweet> Tweets {
			get;
			set;
		}

	}
}

