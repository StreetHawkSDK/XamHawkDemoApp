using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class FeedsPage : ContentPage
	{
		public FeedsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}

		private void buttonFetchFeedClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkFeeds>().ReadFeedData(0, delegate (System.Collections.Generic.List<SHFeedObject> arrayFeeds, string error)
				{
					Device.BeginInvokeOnMainThread(() =>
						{
							if (error != null)
							{
								DisplayAlert("Fetch feeds meet error:", error, "OK");
							}
							else
							{
								string feeds = string.Empty;
								for (int i = 0; i < arrayFeeds.Count; i++)
								{
									SHFeedObject feed = arrayFeeds[i];
									feeds = string.Format("Title: {0}; Message: {1}; Campaign: {2}; Content: {3}. \r\n{4}", feed.title, feed.message, feed.campaign, feed.content, feeds);
									DependencyService.Get<IStreetHawkFeeds>().SendFeedAck(feed.feed_id);
									DependencyService.Get<IStreetHawkFeeds>().NotifyFeedResult(feed.feed_id, 1);
									DependencyService.Get<IStreetHawkFeeds>().NotifyFeedResult(feed.feed_id, "", "accepted", false, false);
								}
								DisplayAlert(string.Format("Fetch {0} feeds:", arrayFeeds.Count), feeds, "OK");
							}
						});
				});
		}
	}
}

