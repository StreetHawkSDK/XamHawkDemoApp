using Android.App;
using Android.Widget;
using Android.OS;
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Geofence;

namespace XamHawkGeofence
{
	[Activity (Label = "XamHawkGeofence", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			//Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			StreetHawk.Instance.SetAppKey ("MyFirstApp");
			StreetHawk.Instance.Init (Application);


			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				SHGeofence.GetInstance(this).StartGeofenceMonitoring();


			};
		}
	}
}
