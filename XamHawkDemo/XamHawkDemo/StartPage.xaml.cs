using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
		}

		public TaskCompletionSource<bool> taskCompletionSource;

		async private void buttonSetupClick(object sender, EventArgs e)
		{
			string appkey = this.textboxAppKey.Text.Trim();
			string gcm = this.textboxGCM.Text;
			if (string.IsNullOrEmpty(appkey))
			{
				await DisplayAlert("App Key is mandatory.", "Please go to https://console.streethawk.com to register your App Key, or use SHSample.", "OK");
				return;
			}
			DependencyService.Get<IStreetHawkAnalytics>().SetAppKey(appkey);
			if (!string.IsNullOrEmpty(gcm))
			{
				//SHService.Instance.shGcmSenderId = gcm; TODO
			}
			this.taskCompletionSource.SetResult(true);
			await Navigation.PopModalAsync();
		}
	}
}

