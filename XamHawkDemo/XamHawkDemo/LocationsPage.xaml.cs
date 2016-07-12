using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class LocationsPage : ContentPage
	{
		public LocationsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);

			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkLocations>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}

		private void buttonEnableServiceClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkLocations>().SetIsLocationServiceEnabled(!DependencyService.Get<IStreetHawkLocations>().GetIsLocationServiceEnabled());
			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkLocations>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		private void buttonStartReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkLocations>().StartLocationReporting();
		}

		private void buttonStopReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkLocations>().StopLocationReporting();
		}

		private void buttonPermissionClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkLocations>().StartLocationWithPermissionDialog(this.textboxPermission.Text);
		}

		private void buttonHomeWorkOnlyClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkLocations>().ReportWorkHomeLocationsOnly();
		}

		private void buttonSetFrequencyClick(object sender, EventArgs e)
		{
			int fg_interval = 0;
			int fg_distance = 0;
			int bg_interval = 0;
			int bg_distance = 0;
			if (int.TryParse(this.textboxFGTimeInterval.Text, out fg_interval) && int.TryParse(this.textboxFGDistance.Text, out fg_distance)
				&& int.TryParse(this.textboxBGTimeInterval.Text, out bg_interval) && int.TryParse(this.textboxBGDistance.Text, out bg_distance))
			{
				DependencyService.Get<IStreetHawkLocations>().UpdateLocationMonitoringParams(fg_interval, fg_distance, bg_interval, bg_distance);
			}
			else
			{
				DisplayAlert("Input value must be int number.", null, "OK");
			}
		}
	}
}

