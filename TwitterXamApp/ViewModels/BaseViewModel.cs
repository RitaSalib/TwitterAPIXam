using System;

using Xamarin.Forms;
using TwitterXamApp;

namespace TwitterXam
{
	public class BaseViewModel:BindableBase
	{
		protected TwitterService newsServices;

		public BaseViewModel ()
		{
			newsServices = new TwitterService ();
			
		}
		private bool _IsDataLoaded;

		public bool IsDataLoaded {
			get { return _IsDataLoaded; } 
			set { SetProperty (ref  _IsDataLoaded, value); }
		}
	}
}

