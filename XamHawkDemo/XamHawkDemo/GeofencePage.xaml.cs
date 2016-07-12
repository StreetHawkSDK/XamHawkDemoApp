using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class GeofencePage : ContentPage
	{
		public GeofencePage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);

			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkGeofence>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}

		private void buttonEnableServiceClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkGeofence>().SetIsLocationServiceEnabled(!DependencyService.Get<IStreetHawkGeofence>().GetIsLocationServiceEnabled());
			this.buttonEnableService.Text = string.Format("Location Service is {0}", DependencyService.Get<IStreetHawkGeofence>().GetIsLocationServiceEnabled() ? "Enabled" : "Disabled");
		}

		private void buttonStartReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkGeofence>().StartGeofenceMonitoring();
		}

		private void buttonStopReportClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkGeofence>().StopGeofenceMonitoring();
		}

		private void buttonPermissionClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkGeofence>().StartGeofenceWithPermissionDialog(this.textboxPermission.Text);
		}
	}
}

