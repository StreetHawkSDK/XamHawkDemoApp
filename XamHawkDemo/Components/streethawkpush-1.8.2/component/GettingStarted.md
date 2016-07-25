# StreetHawk Push

StreetHawk Push component lets you send push messages to your application. Depending on your application's current state, if your application in foreground, the push notification overlays on the current screen as a notification dialog with user to take action and for application in background, the SDK generates a notification in notification bar. Push modules also support custom dialog. 

## Register
 
Register your application [here](https://console.streethawk.com/static/bb/#login) and reserve an AppKey for your application. The appkey is required to register install for your application.

## Prerequisite

StreetHawk's Geofence component depends on StreetHawk's Analytics component and hence needs to be included in your application. Documentaton for Analytics component is as below.
* [iOS] (https://streethawk.freshdesk.com/solution/articles/5000688905-analytics)
* [Android] (https://streethawk.freshdesk.com/solution/articles/5000688897-analytics)

Push notification configured for your application
*[iOS](https://streethawk.freshdesk.com/solution/articles/5000609001-configure-push-messaging-ios-)
*[Android](https://streethawk.freshdesk.com/solution/articles/5000608997-configure-push-messaging-android-)


## iOS Integration

Include StreetHawk Push component as shown below. 
```
using StreethawkIOS.Core;
using StreethawkIOS.Push;
```
Now add the below mention code in FinishedLaunching function of AppDelegate class of your application. Must call at least one function of Push module to make sure link to it.  For very simple use case, just add this line:
```
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//Simply call one function of Push module to make sure linking to it.
            SHPush.instance().isDefaultNotificationEnabled = true;
```

## Android Integration

* Include Component Google play services - CloudMessaging (GCM)
* Modify AndroidManifest.xml
Add the following permissions in your application's AndroidManifest.xml
```
<manifest>
...
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    <uses-permission android:name="android.permission.GET_TASKS" />
    <uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />

    
    <permission
        android:name="<APP_PACKAGE_NAME>.permission.C2D_MESSAGE"
        android:protectionLevel="signature" />

    <uses-permission android:name="<APP_PACKAGE_NAME>.permission.C2D_MESSAGE" />
    <uses-permission android:name="com.google.android.c2dm.permission.RECEIVE" />
    <uses-permission android:name="android.permission.WAKE_LOCK" />
    
    <!-- To support badges on devices -->
    <uses-permission android:name="com.htc.launcher.permission.READ_SETTINGS" />
    <uses-permission android:name="com.htc.launcher.permission.UPDATE_SHORTCUT" />
    <uses-permission android:name="com.sonyericsson.home.permission.BROADCAST_BADGE" />
    <uses-permission android:name="com.sec.android.provider.badge.permission.READ" />
    <uses-permission android:name="com.sec.android.provider.badge.permission.WRITE" />

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

         <service
            android:name="com.streethawk.library.push.SHGcmListenerService"
            android:exported="false">
            <intent-filter>
                <action android:name="com.google.android.c2dm.intent.RECEIVE" />
            </intent-filter>
        </service>

        <receiver android:name="com.streethawk.library.push.PushNotificationBroadcastReceiver">
            <intent-filter>
                <action android:name="com.streethawk.intent.action.pushnotification" />
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_DECLINED" />
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_POSTPONED" />
                <action android:name="com.streethawk.intent.action.gcm.STREETHAWK_ACCEPTED" />
                <action android:name="com.streethawk.intent.action.APP_STATUS_NOTIFICATION" />
            </intent-filter>
        </receiver>

        <receiver
            android:name="com.google.android.gms.gcm.GcmReceiver"
            android:permission="com.google.android.c2dm.permission.SEND">
            <intent-filter>
                <action android:name="com.google.android.c2dm.intent.REGISTRATION" />
                <action android:name="com.google.android.c2dm.intent.RECEIVE" />

                <category android:name="<APP_PACKAGE_NAME>" />
            </intent-filter>
        </receiver>

        <service
            android:name="com.streethawk.library.push.SHInstanceIDListenerService"
            android:enabled="true"
            android:exported="true">
            <intent-filter>
                <action android:name="com.google.android.gms.iid.InstanceID"/>
            </intent-filter>
        </service>


	</application>
```

* Modify Launcher Activity Class
Include Analytics and Push components as shown below
```
using Com.Streethawk.Library.Core;
using Com.Streethawk.Library.Push;
```
Now add the below mention code in OnCreate() function of  Launcher class of your application

```
namespace XamHawkPush
{
	[Activity (Label = "XamHawkPush", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity,ISHEventObserver
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			StreetHawk.Instance.SetAppKey ("<APPKEY>"); //Replace wuth APPKEY for your applicaion
			Push.GetInstance (this).RegisterForPushMessaging ("<PROJECT NUMBER OF YOUR APPLICATION>"); //Replace with Project number
			StreetHawk.Instance.Init (Application);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}

		public void OnInstallRegistered(string installId) {
			Push.GetInstance (this).AddPushModule ();
		}

	}
}
```

## Documentation

Click the below links for detailed documentation.
* [iOS](https://streethawk.freshdesk.com/solution/articles/5000688909-geofence)
* [Android](https://streethawk.freshdesk.com/solution/articles/5000688901-geofence)