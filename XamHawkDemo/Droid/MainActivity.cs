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

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace XamHawkDemo.Droid
{
	[Activity(Label = "XamHawkDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,
	                                           IStreetHawkAnalytics,ISHEventObserver,
	                                           IStreetHawkPush,ISHObserver,
	                                           IStreetHawkGrowth,IGrowth,
	                                           IStreetHawkBeacon,INotifyBeaconTransition,
	                                           IStreetHawkGeofence,INotifyGeofenceTransition,
	                                           IStreetHawkLocations,
	                                           IStreetHawkFeeds,ISHFeedItemObserver
	{


		private static Application mApplication;
		private static Activity mActivity;



		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
			mApplication = Application;
			mActivity = this;
		}

		public void DisplayLog(string tag, string logline)
		{
			Log.Error(tag,logline);
		}


		public void DisplayBadge(int badgeCount)
		{
			//TODO
		}

		public string GetAppKey()
		{
			return StreetHawk.Instance.GetAppKey(mApplication.ApplicationContext);
		}

		public string GetCurrentFormattedDateTime()
		{
			//TODO
			return null;
		}

		public string GetFormattedDateTime(long time)
		{
			//TODO
			return null;
		}

		public string GetInstallId()
		{
			return StreetHawk.Instance.GetInstallId(mApplication.ApplicationContext);
		}

		public string GetSHLibraryVersion()
		{
			//TODO
			return null;
		}

		public void IncrementTag(string key)
		{
			StreetHawk.Instance.IncrementTag(key);
		}

		public void IncrementTag(string key, int incrValue)
		{
			StreetHawk.Instance.IncrementTag(key,incrValue);
		}

		public void Init()
		{
			StreetHawk.Instance.Init(mApplication);
		}

		public void NotifyViewEnter(string viewName)
		{
			StreetHawk.Instance.NotifyViewEnter(viewName);
		}

		public void NotifyViewExit(string viewName)
		{
			StreetHawk.Instance.NotifyViewExit(viewName);
		}

		private static OnInstallRegisteredCallback mInstallRegisterCallback;
		public void RegisterForInstallEvent(OnInstallRegisteredCallback cb)
		{
			mInstallRegisterCallback = cb;
		}

		public void RemoveTag(string key)
		{
			StreetHawk.Instance.RemoveTag(key);
		}

		public void SendSimpleFeedback(string title, string message)
		{
			StreetHawk.Instance.SendSimpleFeedback(title,message);
		}

		public void SetAdvertisementId(string id)
		{
			StreetHawk.Instance.SetAdvertisementId(mApplication.ApplicationContext,id);
		}

		public void SetAppKey(string appKey)
		{
			StreetHawk.Instance.SetAppKey(appKey);
		}

		public void TagCuid(string cuid)
		{
			StreetHawk.Instance.TagCuid(cuid);
		}

		public void TagDateTime(string key, string value)
		{
			StreetHawk.Instance.TagDatetime(key,value);
		}

		public void TagNumeric(string key, double value)
		{
			StreetHawk.Instance.TagNumeric(key,value);
		}

		public void TagString(string key, string value)
		{
			StreetHawk.Instance.TagString(key,value);
		}

		public void TagUserLanguage(string language)
		{
			StreetHawk.Instance.TagUserLanguage(language);
		}

		public void OnInstallRegistered(string installId)
		{
			if(null!=mInstallRegisterCallback)
				mInstallRegisterCallback.Invoke(installId);
		}

		/*StreetHawk Push*/
		public void ForcePushToNotificationBar(bool status)
		{
			Push.GetInstance(mApplication.ApplicationContext).ForcePushToNotificationBar(status);
		}

		public bool IsUsePush()
		{
			return true;
		}

		public void setUseCustomDialog(bool answer)
		{
			Push.GetInstance(mApplication.ApplicationContext).SetUseCustomDialog(answer);
		}

		private static RegisterForShReceivedRawJSONCallback mRawJsonCallback;
		public void RegisterForRawJSON(RegisterForShReceivedRawJSONCallback cb)
		{
			mRawJsonCallback = cb;
		}

		private static RegisterForShNotifyAppPageCallback mAppPageCallback;
		public void ShNotifyAppPage(RegisterForShNotifyAppPageCallback cb)
		{
			mAppPageCallback = cb;
		}

		private static RegisterForOnReceivePushDataCallback mPushDataCallback;
		public void OnReceivePushData(RegisterForOnReceivePushDataCallback cb)
		{
			mPushDataCallback = cb;
		}

		private static RegisterForOnReceiveResultCallback mPushResultCallback;
		public void OnReceiveResult(RegisterForOnReceiveResultCallback cb)
		{
			mPushResultCallback = cb;
		}

		private static RegisterForOnReceiveNonSHPushPayloadCallback mNonSHPayloadCallback;
		public void OnReceiveNonSHPushPayload(RegisterForOnReceiveNonSHPushPayloadCallback cb)
		{
			mNonSHPayloadCallback = cb;
		}

		public void SendPushResult(string msgid, int result)
		{
			Push.GetInstance(mApplication.ApplicationContext).SendPushResult(msgid, result);
		}

		public int GetAlertSettings()
		{
			return Push.GetInstance(mApplication.ApplicationContext).ShGetAlertSettings();
		}

		public void SetAlertSettings(int minutes)
		{
			Push.GetInstance(mApplication.ApplicationContext).ShAlertSetting(minutes);
		}

		public string GetAppPage()
		{
			//TODO
			return null;
		}

		public int GetIcon(string iconName)
		{
			//TODO 
			return -1;
		}

		public void GetButtinPairFromId()
		{
			//TODO
		}

		public void SetInteractivePushBtnPairs()
		{
			//TODO
		}

		public void RegisterForPushMessaging(string projectNumber)
		{
			Push.GetInstance(mApplication.ApplicationContext).RegisterForPushMessaging(projectNumber);
		}

		public void AddPushModule()
		{
			Push.GetInstance(mApplication.ApplicationContext).AddPushModule();
		}

		public void OnReceiveNonSHPushPayload(Bundle p0)
		{
			throw new NotImplementedException();
		}

		public void OnReceivePushData(PushDataForApplication data)
		{
			if (null != mPushDataCallback)
			{
				//TODO
				//mPushDataCallback.Invoke(data)
			}
		}

		public void OnReceiveResult(PushDataForApplication data, int result)
		{
			if (null != mPushResultCallback)
			{
				//TODO
				//mPushResultCallback.Invoke(data, result);
			}
		}

		public void ShNotifyAppPage(string appPage)
		{
			if (null != mAppPageCallback)
			{
				mAppPageCallback.Invoke(appPage);
			}
		}

		public void ShReceivedRawJSON(string title, string message, string json)
		{
			if (null != mRawJsonCallback)
			{
				mRawJsonCallback.Invoke(title, message, json);
			}
		}

		/*Growth implementation*/

		private static RegisterForErrorForShareURLCallback mErrorCallback;
		public void RegisterForErrorForShareURL(RegisterForErrorForShareURLCallback cb)
		{
			mErrorCallback = cb;
		}

		private static RegisterForDeeplinkURLCallback mDeeplinkURLCallback;
		public void RegisterForDeeplinkURL(RegisterForDeeplinkURLCallback cb)
		{
			mDeeplinkURLCallback = cb;
		}

		public void AddGrowthModule()
		{
			//TODO
			throw new NotImplementedException();
		}

		private static RegisterForShareURLCallback mShareUrlCallback;

		public void GetShareUrlForAppDownload(string utm_campaign, string share_url, RegisterForShareURLCallback cb)
		{
			Log.Error("Anurag", "Activity in GetShareUrlForAppDownload" + this);
			if (null != cb)
			{
				mShareUrlCallback = cb;
				Growth.GetInstance(mActivity).OriginateShareWithCampaign(utm_campaign, share_url, this);
			}
			else 
			{
				Growth.GetInstance(mActivity).OriginateShareWithCampaign(utm_campaign, share_url,null);
			}
		}

		public void GetShareUrlForAppDownload(string utm_campaign, string deeplink_uri, string utm_source, string utm_medium, string utm_term, string campaign_content, string default_url, RegisterForShareURLCallback cb)
		{
			throw new NotImplementedException();
		}

		public void OnReceiveDeepLinkUrl(string deeplinkUrl)
		{
			if (null != mDeeplinkURLCallback)
			{
				mDeeplinkURLCallback.Invoke(deeplinkUrl);
			}
		}

		public void OnReceiveErrorForShareUrl(JSONObject p0)
		{
			if (null != mErrorCallback)
			{
				//TODO
			}

		}

		public void OnReceiveShareUrl(string shareUrl)
		{
			if (null != mShareUrlCallback)
			{
				mShareUrlCallback.Invoke(shareUrl);
			}
		}


		/*Beacons*/

		private static RegisterForBeaconCallback mBeaconCallBack;
		public void RegisterForBeaconStatus(RegisterForBeaconCallback cb)
		{
			mBeaconCallBack = cb;
		}

		public int ShEnterBeacon(string uuid, int major, int minor, double distance)
		{
			return Beacons.GetInstance(mApplication.ApplicationContext).ShEnterBeacon(uuid,major,minor,distance);
		}

		public int ShExitBeacon(string uuid, int major, int minor)
		{
			return Beacons.GetInstance(mApplication.ApplicationContext).ShExitBeacon(uuid, major, minor);
		}

		public void StopBeaconMonitoring()
		{
			Beacons.GetInstance(mApplication.ApplicationContext).StopBeaconMonitoring();
		}

		public void StartBeaconMonitoring()
		{
			Beacons.GetInstance(mApplication.ApplicationContext).StartBeaconMonitoring();
		}

		public void NotifyBeaconDetected()
		{
			if (null != mBeaconCallBack)
			{
				mBeaconCallBack.Invoke();
			}
		}

		/*Geofence */

		private static RegisterGeofenceEnterCallback mGeofenceEnterCallBack;
		public void RegisterForGeofenceEnter(RegisterGeofenceEnterCallback cb)
		{
			mGeofenceEnterCallBack = cb;
		}

		private static RegisterGeofenceExitCallback mGeofenceExitCallBack;
		public void RegisterForGeofenceExit(RegisterGeofenceExitCallback cb)
		{
			mGeofenceExitCallBack = cb;
		}

		public void StopGeofenceMonitoring()
		{
			SHGeofence.GetInstance(mApplication.ApplicationContext).StopMonitoring();
		}

		public void StartGeofenceMonitoring()
		{
			SHGeofence.GetInstance(mApplication.ApplicationContext).StartGeofenceMonitoring();
		}

		public void OnDeviceEnteringGeofence()
		{
			if (null != mGeofenceEnterCallBack)
			{
				mGeofenceEnterCallBack.Invoke();
			}
		}

		public void OnDeviceLeavingGeofence()
		{
			if (null != mGeofenceExitCallBack)
			{
				mGeofenceExitCallBack.Invoke();
			}
		}

		/* Locations*/

		public void StartLocationReporting()
		{
			SHLocation.GetInstance(mApplication.ApplicationContext).StartLocationReporting();
		}

		public void StopLocationReporting()
		{
			SHLocation.GetInstance(mApplication.ApplicationContext).StopLocationReporting();
		}

		public void ReportWorkHomeLocationsOnly()
		{
			SHLocation.GetInstance(mApplication.ApplicationContext).ReportWorkHomeLocationsOnly();
		}

		public void updateLocationMonitoringParams(int UPDATE_INTERVAL_FG, int UPDATE_DISTANCE_FG, int UPDATE_INTERVAL_BG, int UPDATE_DISTANCE_BG)
		{
			SHLocation.GetInstance(mApplication.ApplicationContext).UpdateLocationMonitoringParams(UPDATE_DISTANCE_FG, UPDATE_DISTANCE_FG, UPDATE_INTERVAL_BG, UPDATE_DISTANCE_BG);
		}


		/*Feeds*/


		public void SendFeedAck(int feedid)
		{
			SHFeedItem.GetInstance(mApplication.ApplicationContext).SendFeedAck(feedid);
		}

		public void NotifyFeedResult(int feedid, int result)
		{
			SHFeedItem.GetInstance(mApplication.ApplicationContext).NotifyFeedResult(feedid, result);
		}

		public void ReadFeedData(int offset)
		{
			SHFeedItem.GetInstance(mApplication.ApplicationContext).ReadFeedData(offset);
		}

		private RegisterForFeedCallback mFeedItemCallback;
		public void RegisterForFeeds(RegisterForFeedCallback cb)
		{
			mFeedItemCallback = cb;
		}

		public void ShFeedReceived(JSONArray p0)
		{
			if (null != mFeedItemCallback)
			{
				mFeedItemCallback.Invoke();
			}
		}
	}
}

