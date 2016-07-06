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

			//SHService.Instance.isDefaultLocationServiceEnabled = false; TODO
			//SHService.Instance.isDefaultNotificationServiceEnabled = false; TODO

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
			DependencyService.Get<IStreetHawkAnalytics>().shDeeplinking( delegate (string openUrl)
			{
				Device.BeginInvokeOnMainThread(() =>
					{
						MainPage.DisplayAlert("Open url: ", openUrl, "OK");
					});
			});

			//TODO
			//SHService.Instance.notifyBeaconDetectCallback = delegate (SHBeaconObj beacon)
			//{
			//	Device.BeginInvokeOnMainThread(() =>
			//		{
			//			string message = string.Format("uuid: {0}, major: {1}, minor: {2}, server id: {3}, inside: {4}.", beacon.uuid, beacon.major, beacon.minor, beacon.serverId, beacon.isInside);
			//			MainPage.DisplayAlert("Enter/Exit beacon: ", message, "OK");
			//		});
			//};
			//SHService.Instance.notifyGeofenceEventCallback = delegate (SHGeofenceObj geofence)
			//{
			//	Device.BeginInvokeOnMainThread(() =>
			//		{
			//			string message = string.Format("latitude: {0}, longitude: {1}, radius: {2}, server id: {3}, inside: {4}.", geofence.latitude, geofence.longitude, geofence.radius, geofence.serverId, geofence.isInside);
			//			MainPage.DisplayAlert("Enter/Exit geofence: ", message, "OK");
			//		});
			//};
			//SHService.Instance.notifyNewFeedCallback = delegate ()
			//{
			//	SHService.Instance.shGetFeedDataFromServer(0, delegate (System.Collections.Generic.List<SHFeedObject> arrayFeeds, string error)
			//		{
			//			Device.BeginInvokeOnMainThread(() =>
			//				{
			//					if (error != null)
			//					{
			//						MainPage.DisplayAlert("New feeds available but fetch meet error:", error, "OK");
			//					}
			//					else
			//					{
			//						string feeds = string.Empty;
			//						for (int i = 0; i < arrayFeeds.Count; i++)
			//						{
			//							SHFeedObject feed = arrayFeeds[i];
			//							feeds = string.Format("Title: {0}; Message: {1}; Content: {2}. \r\n{3}", feed.title, feed.message, feed.content, feeds);
			//							SHService.Instance.reportFeedAck(feed.feed_id);
			//							SHService.Instance.reportFeedRead(feed.feed_id, SHFeedResult.SHFeedResult_Accept);
			//						}
			//						MainPage.DisplayAlert(string.Format("New feeds available and fetch {0}:", arrayFeeds.Count), feeds, "OK");
			//					}
			//				});
			//		});
			//};
			//			SHService.Instance.pushDataCallback = delegate(PushDataForApplication pushData) 
			//			{
			//				Device.BeginInvokeOnMainThread(() => 
			//					{
			//						string message = string.Format("msgid: {0}; code: {1}; action: {2};\r\ntitle: {3}\r\nmessage: {4}\r\ndata: {5}", pushData.msgID, pushData.code, pushData.action, pushData.title, pushData.message, pushData.data);
			//						MainPage.DisplayAlert("Show custom dialog:", message, "Continue");
			//						SHService.Instance.sendPushResult(pushData.msgID, SHPushResult.SHPushResult_Accept);
			//					});
			//			};
			//			SHService.Instance.pushResultCallback = delegate(PushDataForApplication pushData, SHPushResult result) 
			//			{
			//				Device.BeginInvokeOnMainThread(() => 
			//					{
			//						string title = string.Format("Push result: {0}", result);
			//						string message = string.Format("msgid: {0}; code: {1}; action: {2};\r\ntitle: {3}\r\nmessage: {4}\r\ndata: {5}", pushData.msgID, pushData.code, pushData.action, pushData.title, pushData.message, pushData.data);
			//						MainPage.DisplayAlert(title, message, "OK");
			//					});						
			//			};
			//SHService.Instance.shRawJsonCallback = delegate (SHJson jsonData)
			//{
			//	Device.BeginInvokeOnMainThread(() =>
			//		{
			//			string message = string.Format("title: {0}\r\nmessage: {1}\r\njson: {2}", jsonData.title, jsonData.message, jsonData.json);
			//			MainPage.DisplayAlert("Receive json push:", message, "OK");
			//		});
			//};
			//SHService.Instance.registerNonSHPushPayloadObserver = delegate (string payload)
			//{
			//	Device.BeginInvokeOnMainThread(() =>
			//		{
			//			MainPage.DisplayAlert("Receive none StreetHawk push:", payload, "OK");
			//		});
			//};
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

