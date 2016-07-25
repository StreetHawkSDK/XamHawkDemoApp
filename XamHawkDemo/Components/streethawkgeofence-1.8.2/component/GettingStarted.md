# StreetHawk Geofence

StreetHawk Geofence component lets you run campaigns based on users presence in a given geofence.

## Register 

Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite

StreetHawk's Geofence component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)


## iOS Integration

Include StreetHawk Geofence component as shown below.
```
using StreethawkIOS.Core;
using StreethawkIOS.Geofence;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application. Must call at least one function of Geofence module to make sure link to it.  For very simple use case, just add this line:
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//Simply call one function of Geofence module to make sure linking to it.
            SHGeofence.instance().isDefaultLocationServiceEnabled = true;
```
Add `NSLocationAlwaysUsageDescription` into Info.plist.

## Android Integration

* Include Component Google play services - Location.
* Modify AndroidManifest.xml
Add the following permissions in your application's AndroidManifest.xml
```
<manifest>
...
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    <uses-permission android:name="android.permission.GET_TASKS" />
    <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />
    <uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
    <uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />

    <application>
    ...
    </application>
</manifest>
```
Add the following code under application of AndroidMainfest.xml 

```
<application>
<uses-library android:name="com.google.android.maps" />
	<receiver
            android:name="com.streethawk.library.core.StreethawkBroadcastReceiver"
            android:enabled="true"
            android:exported="true" >
            <intent-filter>
                <action android:name="android.location.PROVIDERS_CHANGED" />
                <action android:name="android.intent.action.TIMEZONE_CHANGED" />
                <action android:name="android.intent.action.BOOT_COMPLETED" />
                <action android:name="android.net.conn.CONNECTIVITY_CHANGE" />
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_APP_STATUS_CHK" />
            </intent-filter>
        </receiver>
        <service
            android:name="com.streethawk.library.core.StreetHawkCoreService"
            android:enabled="true"
            android:exported="true" >
        </service>
        <service
            android:name="com.streethawk.library.geofence.GeofenceService"
            android:exported="false">
        </service>
        <receiver
            android:name="com.streethawk.library.geofence.SHCoreModuleReceiver"
            android:enabled="true"
            android:exported="true">
            <intent-filter>
                <action android:name="com.streethawk.intent.action.APP_STATUS_NOTIFICATION" />
                <action android:name="android.location.PROVIDERS_CHANGED" />
            </intent-filter>
        </receiver>

	</application>
```

* Modify Launcher Activity Class
Include Analytics and Geofence components as shown below
```
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Geofence;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamHawkGeofence
{
	[Activity (Label = "XamHawkGeofence", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
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
				//Start geofence monitoring
				SHGeofence.GetInstance(this).StartGeofenceMonitoring();
			};
		}
	}
```
Note: Start geofence monitoring anytime after calling StreetHawk init by using the code below


## Documentation

Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688909-geofence)
* [Android](https://streethawk.freshdesk.com/solution/articles/5000688901-geofence)