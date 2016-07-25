# StreetHawk Beacon

StreetHawk Beacon component lets you detect Beacons and run campaings based on user's presence in a beacon's region. 

## Register 

Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite

StreetHawk's Beacon component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)


## iOS Integration
Include StreetHawk Beacon component as shown below.

```
using StreethawkIOS.Core;
using StreethawkIOS.Beacon;
```

Now add the below mention code in FinishedLaunching function of AppDelegate class of your application. Must call at least one function of Beacon module to make sure link to it.  For very simple use case, just add this line:

```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//Simply call one function of Beacon module to make sure linking to it.
            SHBeacon.instance().isDefaultLocationServiceEnabled = true;
```

Add `NSLocationAlwaysUsageDescription` into Info.plist.

## Android Integration

* Modify AndroidManifest.xml
Add the following permissions in your application's AndroidManifest.xml

```
<manifest>
...
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    <uses-permission android:name="android.permission.GET_TASKS" />
    <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />
    
    <uses-permission android:name="android.permission.BLUETOOTH" />
    <uses-permission android:name="android.permission.BLUETOOTH_ADMIN" />
    
    <application>
    ...
    </application>
</manifest>
```

Add the following code under application of AndroidMainfest.xml 


```
<application>
<service
            android:name="com.streethawk.library.beacon.BeaconServiceL"
            android:enabled="true"
            android:exported="true" >
        </service>
        <service
            android:name="com.streethawk.library.beacon.BeaconServiceKK"
            android:enabled="true"
            android:exported="true" >
        </service>

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

        <receiver
            android:name="com.streethawk.library.beacon.SHBeaconModuleBC"
            android:enabled="true"
            android:exported="true" >
            <intent-filter>
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_APP_BEACON_WIFI_MODE" />
                <action android:name="android.bluetooth.adapter.action.STATE_CHANGED" />
                <action android:name="android.intent.action.BOOT_COMPLETED" />
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_APP_STATUS_CHK" />
                <action android:name="com.streethawk.intent.action.APP_STATUS_NOTIFICATION" />
            </intent-filter>
        </receiver>
	</application>
```

* Modify Launcher Activity Class
Include StreetHawkAnalytics and Beacon component as shown below

```
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Beacon;
```

Now add the below mention code in OnCreate() function of  Launcher class of your application


```
namespace XamHawkBeacon
{
	[Activity (Label = "XamHawkBeacon", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			StreetHawk.Instance.SetAppKey ("<APPKEY>"); // Replace with your application's app_key
			StreetHawk.Instance.Init (Application);
			
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				// Start beacon monitoring
				Beacons.GetInstance(this).StartBeaconMonitoring();
			};
		}
	}
}
```

## Documentation
Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688908-beacons)
* [Android](https://streethawk.freshdesk.com/solution/articles/5000688900-beacons)




