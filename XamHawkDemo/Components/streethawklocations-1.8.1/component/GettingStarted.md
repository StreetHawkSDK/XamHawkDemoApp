# StreetHawk Locations

Location component is used for running location based campaigns based on location of your application's user. Also module can be used for calculating the Work and Home locations of your application's user.

## Register 
Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite

StreetHawk's Location component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)


## iOS Integration
Include StreetHawk Location component as shown below.
```
using StreethawkIOS.Core;
using StreethawkIOS.Location;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application. Must call at least one function of Location module to make sure link to it.  For very simple use case, just add this line:
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//Simply call one function of Location module to make sure linking to it.
            SHLocation.instance().isDefaultLocationServiceEnabled = true;
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
<application
        android:allowBackup="true"
        android:label="@string/app_name">
        <service
            android:name="com.streethawk.library.locations.StreethawkLocationService"
            android:enabled="true"
            android:exported="true" />
        <receiver
            android:name="com.streethawk.library.locations.LocationReceiver"
            android:enabled="true"
            android:exported="true">
            <intent-filter>
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_LOCATIONS" />
                <action android:name="android.location.PROVIDERS_CHANGED" />
            </intent-filter>
        </receiver>
    </application>
```

* Modify Launcher Activity Class
Include Analytics and Location components as shown below
```
using Com.Streethawk.Library.Locations;
using Com.Streethawk.Library.Core;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamHawkLocations
{
	[Activity (Label = "XamHawkLocations", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			StreetHawk.Instance.SetAppKey ("<APP_KEY>"); // Replace with your application's AppKey
			StreetHawk.Instance.Init (Application);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				// Start location reporting 
				SHLocation.GetInstance(this).StartLocationReporting();
			};
		}
	}
}
```
## Documentation

Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android](https://console.streethawk.com/static/bb/#login)




