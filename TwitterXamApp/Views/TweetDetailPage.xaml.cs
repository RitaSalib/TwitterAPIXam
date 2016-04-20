using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TwitterXamApp
{
	public partial class TweetDetailPage : ContentPage
	{
		public Tweet tweet {
			get;
			set;
		}
		public TweetDetailPage (Tweet tweet)
		{
			InitializeComponent ();
			Title="Summary";
			this.BindingContext = tweet;
		}
	}
}

