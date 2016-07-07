using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class GrowthPage : ContentPage
	{
		public GrowthPage()
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

		private void buttonSubmitCallbackClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxDeeplinking.Text))
			{
				DisplayAlert("Please input deeplinking url.", "Deeplinking url is mandatory.", "OK");
				return;
			}
			string campaign = this.textboxCampaign.Text;
			string source = this.textboxSource.Text;
			string medium = this.textboxMedium.Text;
			string term = this.textboxTerm.Text;
			string deeplinking = this.textboxDeeplinking.Text;
			string defaultUrl = this.textboxDefaultUrl.Text;
			string content = this.textboxContent.Text;
			DependencyService.Get<IStreetHawkGrowth>().GetShareUrlForAppDownload(campaign, deeplinking, source, medium, term, content, defaultUrl, delegate (string shareUrl, string error)
			   {
				   Device.BeginInvokeOnMainThread(() =>
					   {
						   if (error == null)
						   {
							   DisplayAlert("Get growth share url:", shareUrl, "OK");
						   }
						   else
						   {
							   DisplayAlert("Share fail with error:", error, "OK");
						   }
					   });
			   });
		}

		private void buttonSubmitChannelClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxDeeplinking.Text))
			{
				DisplayAlert("Please input deeplinking url.", "Deeplinking url is mandatory.", "OK");
				return;
			}
			string campaign = this.textboxCampaign.Text;
			string deeplinking = this.textboxDeeplinking.Text;
			string defaultUrl = this.textboxDefaultUrl.Text;
			DependencyService.Get<IStreetHawkGrowth>().GetShareUrlForAppDownload(campaign, deeplinking, defaultUrl);
		}
	}
}

