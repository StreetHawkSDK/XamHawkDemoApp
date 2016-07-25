# StreetHawk Growth

StreetHawk Growth feature lets your user share your application with friends. Also the feature can be extended to invite the new user to a deeplinked page inside your application. Create a Share button inside your application and call InviteFriendsToDownloadApplication to generate the share url. StreetHawk SDK will then ask user ways to share the generated url. That is (email, post on Facebook etc)

## Register 
Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite
StreetHawk's Beacon component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)


## iOS Integration
Include StreetHawk Growth component as shown below.
```
using StreethawkIOS.Core;
using StreethawkIOS.Growth;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application.
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//streethawk handle open url sample.
            SHApp.instance ().shDeeplinking = delegate (NSUrl openUrl) 
            {
                //receive deeplinking url and do whatever you want
            };
```
Create a share button to send share link to friends. 
```
       string ID = "ShareViaFacebook"
       string shareLink = "recipeApp://homepage?recipe=chocolatechipcookie";
       string default_url = "http://recipeApp.com/chocolatechipcookie";
       SHGrowth.instance().originateShareWithSourceSelectionID, shareLink, default_url);
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
            android:name="com.streethawk.library.growth.Register"
            android:enabled="true" >
            <intent-filter>
                <action android:name="com.android.vending.INSTALL_REFERRER" />
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
Include StreetHawkAnalytics and StreetHawkGrowth components as shown below
```
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Growth;
// Add for deeplinking
using Android.Content;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamGrowth
{
	// Register for deeplinking parameters 
	[Activity (Label = "XamGrowth", MainLauncher = true, Icon = "@mipmap/icon")]
	[IntentFilter (new[]{Intent.ActionView},
		Categories=new[]{Intent.CategoryLauncher,Intent.CategoryBrowsable,Intent.CategoryDefault},
		Icon="@mipmap/icon",
		DataScheme="shsample", // define scheme here
		DataHost="setparams")] // define host here
	
    // Implement ISHEVENTObserver for starting Growth module after install has been successfully registered
    // Implement IGrowth to receive sharable url from StreetHawk
	public class MainActivity : Activity,ISHEventObserver,IGrowth
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

				string ID = "ShareViaFacebook";
				string shareLink = "recipeApp://homepage?recipe=chocolatechipcookie";
				string utm_source = "Facebook";
				string utm_medium = "cpc";
				string utm_term = "facebookAdd";
				string campaign_content = "best chocolate chip cookie recipe";
				string default_url = "http://recipeApp.com/chocolatechipcookie";

				Growth.GetInstance(this).GetShareUrlForAppDownload(ID,shareLink,utm_source,utm_medium,utm_term,campaign_content,default_url,this);
			};
		}

		// Add growth module after install is registered with StreetHawk server
		public void OnInstallRegistered(string installId){
			Growth.GetInstance (this).AddGrowthModule ();
		}
		public void OnReceiveShareUrl(string shareUrl){
			// Add code for sharing url here
			Android.Util.Log.Info ("StreetHawk", "Share Url " + shareUrl);
		}
		public void OnReceiveErrorForShareUrl(JSONObject errorResponse){
		}
	}
}
```
## Documentation
Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688906-growth)
* [Android](https://streethawk.freshdesk.com/solution/articles/5000688898-growth)




