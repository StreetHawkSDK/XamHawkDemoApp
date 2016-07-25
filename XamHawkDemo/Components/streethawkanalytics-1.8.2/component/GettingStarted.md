# StreetHawk Analytics

StreetHawk Analytics component reports various vital raw data to StreetHawk servers which is further processed and used for various analytics for your application.  The module also provides API for tagging the install, identifying the users and tracking various important events inside your application. 

## Register 
Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## iOS Integration
Include StreetHawk Analytics component as shown below.
```
using StreethawkIOS.Core;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application.
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//streethawk register install sample.
			SHApp.instance ().appKey = "<APP_KEY>"; // Replace with your application's AppKey
			SHApp.instance ().enableLogs = true;
			SHApp.instance ().iTunesId = "<iTunes_AppId>"; // Replace with your App's id in AppStore
			SHApp.instance ().streethawkinit ();
			
			//Tagging example
			SHApp.instance().tagCuid("<UNIQUE_ID>"); // Replace with user's unique id such as user'semail address
```

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
    <application>
    ...
    </application>
</manifest>
```
Add the following code under application of AndroidMainfest.xml 

```
<application>
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
	</application>
```

* Modify Launcher Activity Class
Include StreetHawkAnalytics component as shown below
```
using Com.Streethawk.Library.Core;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamHawkAnalytics
{
	[Activity (Label = "XamHawkAnalytics", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			StreetHawk.Instance.SetAppKey ("<APP_KEY>");  //Replace with your application's app_key
			StreetHawk.Instance.Init (Application);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);

				//Sample code Tagging cuid

				string cuid = "support@streethawk.com";
				StreetHawk.Instance.TagCuid(cuid);

			};
		}
	}
}
```

## Documentation

Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android](https://console.streethawk.com/static/bb/#login)




