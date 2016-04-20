using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TwitterXamApp
{
	public partial class MyFeedPage : ContentPage
	{
		public MyFeedPageViewModel ViewModel {
			get;
			set;
		}
		public MyFeedPage ()
		{
			InitializeComponent ();
			Title="My Twitter Feed";
			ViewModel = new MyFeedPageViewModel ();
			this.BindingContext = ViewModel;
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			await ViewModel.Init ();
			listView.ItemsSource = ViewModel.Tweets;
		}

		async void OnItemTapped(object sender, ItemTappedEventArgs args)
		{
			var tweet= args.Item as Tweet;
			if (tweet != null)
				await this.Navigation.PushAsync (new TweetDetailPage (tweet));
		}
	}
}

