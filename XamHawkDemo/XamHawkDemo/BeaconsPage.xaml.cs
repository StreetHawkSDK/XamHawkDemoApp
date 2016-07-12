using System;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class BeaconsPage : ContentPage
	{
		public BeaconsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);

			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkBeacon>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}

		private void buttonEnableServiceClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkBeacon>().SetIsLocationServiceEnabled(!DependencyService.Get<IStreetHawkBeacon>().GetIsLocationServiceEnabled());
			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkBeacon>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		private void buttonStartReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkBeacon>().StartBeaconMonitoring();
		}

		private void buttonStopReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkBeacon>().StopBeaconMonitoring();
		}
	}
}

