using Xamarin.Forms;
using System.Threading.Tasks;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new XamHawkDemoPage())
			{
				BarBackgroundColor = Color.FromRgb(101, 46, 145),
				BarTextColor = Color.White,
			};
		}

		static Task<bool> SetupApp(NavigationPage navpage)
		{
			var tcs = new TaskCompletionSource<bool>();
			StartPage startPage = new StartPage();
			startPage.taskCompletionSource = tcs;
			navpage.Navigation.PushModalAsync(startPage);
			return tcs.Task;
		}

		protected override async void OnStart()
		{
			// Handle when your app starts

			// Check whether need to setup app key and GCM.
			if (string.IsNullOrEmpty(DependencyService.Get<IStreetHawkAnalytics>().GetAppKey()))
			{
				await SetupApp((NavigationPage)this.MainPage);
			}

			//Optional: enable XCode console logs.
			DependencyService.Get<IStreetHawkAnalytics>().SetEnableLogs(true);
			//Optional: iOS specific, set AppStore Id for upgrading or rating App.
			DependencyService.Get<IStreetHawkAnalytics>().SetsiTunesId("944344799");
			//Optional: if App is allowed to get advertising identifier, pass to SDK.
			DependencyService.Get<IStreetHawkAnalytics>().SetAdvertisementId("BEE83220-9385-4B36-81E1-BF4305834093");

			//Optional: not enable location when launch, delay ask for permission. Below three  APIs are equivalent. 
			//DependencyService.Get<IStreetHawkBeacon>().SetIsDefaultLocationServiceEnabled(false);
			//DependencyService.Get<IStreetHawkGeofence>().SetIsDefaultLocationServiceEnabled(false);
			DependencyService.Get<IStreetHawkLocations>().SetIsDefaultLocationServiceEnabled(false);

			//Optional: not enable notification when launch, delay ask for permission.
			DependencyService.Get<IStreetHawkPush>().SetIsDefaultNotificationServiceEnabled(false);

			// Initialize StreetHawk when App starts.
			//Mandatory: set app key and call init.
			DependencyService.Get<IStreetHawkAnalytics>().Init(); 

			//Optional: callback when install register successfully.
			DependencyService.Get<IStreetHawkAnalytics>().RegisterForInstallEvent(delegate (string installId)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						MainPage.DisplayAlert("Install register successfully: ", installId, "OK");
					});
			});

			//Optional: callback when open url.
			DependencyService.Get<IStreetHawkAnalytics>().RegisterForDeeplinkURL( delegate (string openUrl)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						MainPage.DisplayAlert("Open url: ", openUrl, "OK");
					});
			});

			//Optional: Callback when enter or exit beacon.
			DependencyService.Get<IStreetHawkBeacon>().RegisterForBeaconStatus( delegate (SHBeaconObj beacon)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						string message = string.Format("uuid: {0}, major: {1}, minor: {2}, server id: {3}, inside: {4}.", beacon.uuid, beacon.major, beacon.minor, beacon.serverId, beacon.isInside);
						MainPage.DisplayAlert("Enter/Exit beacon: ", message, "OK");
					});
			});

			//Optional: Callback when enter or exit geofence.
			DependencyService.Get<IStreetHawkGeofence>().RegisterForGeofenceStatus( delegate (SHGeofenceObj geofence)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						string message = string.Format("latitude: {0}, longitude: {1}, radius: {2}, server id: {3}, inside: {4}, title: {5}.", geofence.latitude, geofence.longitude, geofence.radius, geofence.serverId, geofence.isInside, geofence.title);
						MainPage.DisplayAlert("Enter/Exit geofence: ", message, "OK");
					});
			});

			//Optional: Callback when new feeds are available.
			DependencyService.Get<IStreetHawkFeeds>().OnNewFeedAvailableCallback( delegate ()
			{
				DependencyService.Get<IStreetHawkFeeds>().ReadFeedData(0, delegate (System.Collections.Generic.List<SHFeedObject> arrayFeeds, string error)
					{
						Device.BeginInvokeOnMainThread(() =>
							{
								if (error != null)
								{
									MainPage.DisplayAlert("New feeds available but fetch meet error:", error, "OK");
								}
								else
								{
									string feeds = string.Empty;
									for (int i = 0; i < arrayFeeds.Count; i++)
									{
										SHFeedObject feed = arrayFeeds[i];
										feeds = string.Format("Title: {0}; Message: {1}; Content: {2}. \r\n{3}", feed.title, feed.message, feed.content, feeds);
										DependencyService.Get<IStreetHawkFeeds>().SendFeedAck(feed.feed_id);
										DependencyService.Get<IStreetHawkFeeds>().NotifyFeedResult(feed.feed_id, SHFeedResult.SHFeedResult_Accept);
									}
									MainPage.DisplayAlert(string.Format("New feeds available and fetch {0}:", arrayFeeds.Count), feeds, "OK");
								}
							});
					});
			});

			//Optional: Callback when receive push notification payload.
			//DependencyService.Get<IStreetHawkPush>().OnReceivePushData(delegate (PushDataForApplication pushData)
			//		   {
			//			   Device.BeginInvokeOnMainThread(() =>
			//				   {
			//					   string message = string.Format("msgid: {0}; code: {1}; action: {2};\r\ntitle: {3}\r\nmessage: {4}\r\ndata: {5}", pushData.msgID, pushData.code, pushData.action, pushData.title, pushData.message, pushData.data);
			//					   MainPage.DisplayAlert("Show custom dialog:", message, "Continue");
			//						//Mandatory: Send push result.
			//						DependencyService.Get<IStreetHawkPush>().SendPushResult(pushData.msgID, SHPushResult.SHPushResult_Accept);
			//				   });
			//		   });

			//Optional: Callback when decide push result.
			//DependencyService.Get<IStreetHawkPush>().OnReceiveResult(delegate (PushDataForApplication pushData, SHPushResult result)
			//		   {
			//			   Device.BeginInvokeOnMainThread(() =>
			//				   {
			//					   string title = string.Format("Push result: {0}", result);
			//					   string message = string.Format("msgid: {0}; code: {1}; action: {2};\r\ntitle: {3}\r\nmessage: {4}\r\ndata: {5}", pushData.msgID, pushData.code, pushData.action, pushData.title, pushData.message, pushData.data);
			//					   MainPage.DisplayAlert(title, message, "OK");
			//				   });
			//		   });

			//Optional: Callback when receive json push.
			DependencyService.Get<IStreetHawkPush>().RegisterForRawJSON( delegate (string title, string message, string JSON)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						string msg = string.Format("title: {0}\r\nmessage: {1}\r\njson: {2}", title, message, JSON);
						MainPage.DisplayAlert("Receive json push:", msg, "OK");
					});
			});

			//Optional: Callback when none 
			DependencyService.Get<IStreetHawkPush>().OnReceiveNonSHPushPayload( delegate (string payload)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						MainPage.DisplayAlert("Receive none StreetHawk push:", payload, "OK");
					});
			});
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

