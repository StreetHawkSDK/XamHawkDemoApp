using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamHawkDemo.Droid;
using Android.Util;
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Push;
using Com.Streethawk.Library.Growth;
using Com.Streethawk.Library.Beacon;
using Com.Streethawk.Library.Geofence;
using Com.Streethawk.Library.Locations;
using Com.Streethawk.Library.Feeds;
using Org.Json;
using StreetHawkCrossplatform;
using System.Collections.Generic;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace XamHawkDemo.Droid
{
	[Activity(Label = "XamHawkDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			new StreetHawkAnalytics(Application);
			new StreetHawkGrowth(this);
			new StreetHawkPush(Application);
			new StreetHawkFeeds(Application);
			new StreetHawkLocation(Application);
			new StreetHawkGeofence(Application);
			new StreetHawkBeacons(Application);
		}
	}
}

