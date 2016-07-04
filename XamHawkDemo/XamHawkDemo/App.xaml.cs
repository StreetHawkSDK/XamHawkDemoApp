using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new XamHawkDemoPage();
		}

		protected override void OnStart()
		{
			DependencyService.Get<IStreetHawkAnalytics>().SetAppKey("MyFirstApp");
			DependencyService.Get<IStreetHawkPush>().RegisterForPushMessaging("491295755890");
			DependencyService.Get<IStreetHawkAnalytics>().Init();

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			DependencyService.Get<IStreetHawkGrowth>().GetShareUrlForAppDownload("Test", "shsample://setparams?param1=30",
																				 /*share*/null);
			DependencyService.Get<IStreetHawkBeacon>().StartBeaconMonitoring();
			DependencyService.Get<IStreetHawkGeofence>().StartGeofenceMonitoring();
		}
	}
}

