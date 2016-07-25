# StreetHawk Feeds

StreetHawk Feeds component lets you send and analyse feeds using StreetHawk

## Register 
Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite
StreetHawk's Beacon component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)


## iOS Integration
Include StreetHawk Feed component as shown below.
```
using StreethawkIOS.Core;
using StreethawkIOS.Feed;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application.
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			SHFeed.instance ().newFeedHandler = delegate {
                SHFeed.instance().feed(0, delegate (NSArray arrayFeeds, NSError error) {
                };   
            };
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
	    <receiver
	             android:name="com.streethawk.library.feeds.SHCoreModuleReceiver"
	             android:enabled="true"
	             android:exported="true" >
	             <intent-filter>
	                 <action android:name="com.streethawk.intent.action.APP_STATUS_NOTIFICATION" />
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
Include Analytics and feeds components as shown below
```
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Feeds;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamHawkFeeds
{
	[Activity (Label = "XamHawkFeeds", MainLauncher = true, Icon = "@mipmap/icon")]
	// Implement ISHFeedItemObserver to receive feed data
	public class MainActivity : Activity,ISHFeedItemObserver
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			StreetHawk.Instance.SetAppKey ("<APPKey>"); // Replace with your application's app_key
			StreetHawk.Instance.Init (Application);
			SHFeedItem.GetInstance (this).RegisterFeedItemObserver (this);  //Register observer to receive feed data

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				SHFeedItem.GetInstance(this).ReadFeedData(0);  // Fetch feed data from StreetHawk
			};
		}
		public void ShFeedReceived(Org.Json.JSONArray value){
		
		}
	}
}
```

## Documentation

Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688911-feeds)
* [Android](https://streethawk.freshdesk.com/solution/articles/5000688903-feeds)




