using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class PushPage : ContentPage
	{
		public PushPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);

			this.buttonEnableService.Text = string.Format("Notification Service is {0}", DependencyService.Get<IStreetHawkPush>().GetIsNotificationServiceEnabled() ? "Enabled" : "Disabled");
			this.textboxGCM.Text = DependencyService.Get<IStreetHawkPush>().GetGcmSenderId();
			this.textboxAlertSettings.Text = DependencyService.Get<IStreetHawkPush>().GetAlertSettings().ToString();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}

		private void buttonEnableServiceClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkPush>().SetIsNotificationServiceEnabled(!DependencyService.Get<IStreetHawkPush>().GetIsNotificationServiceEnabled());
			this.buttonEnableService.Text = string.Format("Notification Service is {0}", DependencyService.Get<IStreetHawkPush>().GetIsNotificationServiceEnabled() ? "Enabled" : "Disabled");
		}

		private void buttonGCMClick(object sender, EventArgs e)
		{
			//DependencyService.Get<IStreetHawkPush>().SetGcmSenderId(this.textboxGCM.Text);
		}

		private void buttonForceToBarClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkPush>().ForcePushToNotificationBar(true);
		}

		private void buttonUseCustomDialogClick(object sender, EventArgs e)
		{
			DependencyService.Get<IStreetHawkPush>().SetUseCustomDialog(this.switchUseCustomDialog.On);
		}

		private void buttonAlertSettingsClick(object sender, EventArgs e)
		{
			int alertSettings = 0;
			if (int.TryParse(this.textboxAlertSettings.Text, out alertSettings))
			{
				DependencyService.Get<IStreetHawkPush>().SetAlertSettings(alertSettings);
			}
			else
			{
				DisplayAlert("Wrong input", "The input value should be int number.", "OK");
			}
		}

		private void buttonInteractivePairButtonsClick(object sender, EventArgs e)
		{
			List<InteractivePush> pairs = new List<InteractivePush>();
			if (!string.IsNullOrEmpty(this.textboxTitle1.Text) && !string.IsNullOrEmpty(this.textboxButtonPos1.Text) && !string.IsNullOrEmpty(this.textboxButtonNeg1.Text))
			{
				InteractivePush pair = new InteractivePush(this.textboxTitle1.Text, this.textboxButtonPos1.Text, this.textboxIconPos1.Text, this.textboxButtonNeg1.Text, this.textboxIconNeg1.Text);
				pairs.Add(pair);
			}
			if (!string.IsNullOrEmpty(this.textboxTitle2.Text) && !string.IsNullOrEmpty(this.textboxButtonPos2.Text) && !string.IsNullOrEmpty(this.textboxButtonNeg2.Text))
			{
				InteractivePush pair = new InteractivePush(this.textboxTitle2.Text, this.textboxButtonPos2.Text, this.textboxIconPos2.Text, this.textboxButtonNeg2.Text, this.textboxIconNeg2.Text);
				pairs.Add(pair);
			}
			DependencyService.Get<IStreetHawkPush>().SetInteractivePushBtnPairs(pairs);
			DisplayAlert("Set successfully.", "Please sent push notification to test.", "OK");
		}
	}
}

