using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class InstallInfoPage : ContentPage
	{
		public InstallInfoPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);

			this.labelAppKey.Text = string.Format("App key: {0}", DependencyService.Get<IStreetHawkAnalytics>().GetAppKey());
			this.labelInstallId.Text = string.Format("Install id: {0}", DependencyService.Get<IStreetHawkAnalytics>().GetInstallId());
			this.labelEnableLog.Text = string.Format("Enable console log: {0}", DependencyService.Get<IStreetHawkAnalytics>().GetEnableLogs());
			this.labelSDKLibrary.Text = string.Format("SDK version: {0}", DependencyService.Get<IStreetHawkAnalytics>().GetSHLibraryVersion());
			this.labelAdvertisement.Text = string.Format("Advertisement id: {0}", DependencyService.Get<IStreetHawkAnalytics>().GetAdvertisementId());
			this.labeliTunesId.Text = string.Format("iTunes id (iOS Specific): {0}", DependencyService.Get<IStreetHawkAnalytics>().GetInstallId());
			this.labelGCMId.Text = string.Format("GCM id (Android Specific): {0}", DependencyService.Get<IStreetHawkPush>().GetGcmSenderId());
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}
	}
}

