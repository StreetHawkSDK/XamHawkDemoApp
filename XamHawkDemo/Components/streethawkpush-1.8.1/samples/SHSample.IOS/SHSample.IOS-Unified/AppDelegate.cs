using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;

using StreethawkIOS.Core;
using StreethawkIOS.Push;

namespace SHSample.IOSUnified
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//optional to delay ask for permission
			SHPush.instance().isDefaultNotificationEnabled = false;

			//streethawk register install sample.
			SHApp.instance ().appKey = "XSample_Unified";
			SHApp.instance ().enableLogs = true;
			SHApp.instance ().iTunesId = "507040546";
			SHApp.instance ().streethawkinit ();

			//streethawk set advertisement id.			
			SHApp.instance().advertisementId = "BEE83220-9385-4B36-81E1-BF4305834093";
			if (SHApp.instance ().advertisementId != "BEE83220-9385-4B36-81E1-BF4305834093") {
				Console.WriteLine ("Test fail: advertisementId get set mismatch.");
			}

			//streethawk handle open url sample.
			SHApp.instance ().shDeeplinking = delegate (NSUrl openUrl) 
			{
				UIAlertView alert = new UIAlertView("Open url handler: ", openUrl.AbsoluteString, null, "OK", null);
				alert.Show();
			};

			//streethawk callback when install register successfully.
			SHApp.instance ().registerEventCallBack = delegate (string installId) 
			{
				InvokeOnMainThread ( () => {
					UIAlertView alert = new UIAlertView ("Install register successfully: ", installId, null, "OK", null);
					alert.Show ();
				});
			};

			//streethawk handle customized notification.
			SHPush.instance ().shSetCustomiseHandler (new MyHandler ());

			//streethawk handle none StreetHawk push payload
			SHPush.instance ().registerNonSHPushPayloadObserver = delegate(NSDictionary payload) {
				InvokeOnMainThread (() => {
					UIAlertView alert = new UIAlertView ("None StreetHawk payload: ", payload.ToString(), null, "OK", null);
					alert.Show ();
				});
			};

			//streethawk set interactive pair buttons.
			InteractivePush pair1 = new InteractivePush("FacebookTwitter", "Facebook", "Twitter");
			InteractivePush pair2 = new InteractivePush ("EmailPhone", "Email", "Phone");
			SHPush.instance ().setInteractivePushBtnPairs (new InteractivePush [2] { pair1, pair2 });

			return true;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}
	}

	class MyHandler : ISHCustomiseHandler
	{
		public override void shRawJsonCallbackWithTitle (string title, string message, string json)
		{
			Console.WriteLine ("raw json title: " + title);
			Console.WriteLine ("raw json message: " + message);
			Console.WriteLine ("raw json content: " + json);
		}

		public override bool onReceive (PushDataForApplication pushData, ClickButtonHandler handler)
		{
			Console.WriteLine ("receive push data action: " + pushData.action.ToString());
			Console.WriteLine ("receive push data code: " + pushData.code.ToString());
			Console.WriteLine ("receive push data title: " + pushData.title);
			Console.WriteLine ("receive push data message: " + pushData.message);
			if (pushData.data != null) 
			{
				Console.WriteLine ("receive push data data: " + pushData.data.ToString ());
			}
			Console.WriteLine ("receive push data msg id: " + pushData.msgID.ToString());
			Console.WriteLine ("receive push data display without dialog: " + pushData.displayWithoutDialog.ToString());
			Console.WriteLine ("receive push data is foreground: " + pushData.isAppOnForeground.ToString());
			Console.WriteLine ("receive push data badge: " + pushData.badge.ToString());
			Console.WriteLine ("receive push data sound: " + pushData.sound);
			Console.WriteLine ("receive push data is slide: " + pushData.isInAppSlide.ToString());
			Console.WriteLine ("receive push data orientation: " + pushData.orientation.ToString());
			Console.WriteLine ("receive push data portion: " + pushData.portion.ToString());
			Console.WriteLine ("receive push data speed: " + pushData.speed.ToString());

			//			if (pushData.action == SHAction.SHAction_OpenUrl) 
			//			{
			//				if (handler != null) 
			//				{
			//					handler (SHResult.SHResult_Accept);
			//				}
			//				return true;
			//			}

			return false;
		}

		public override void onReceiveResult (PushDataForApplication pushData, SHPushResult result)
		{
			Console.WriteLine ("receive result: " + result.ToString());
			Console.WriteLine ("receive result action: " + pushData.action.ToString());
			Console.WriteLine ("receive result code: " + pushData.code.ToString());
			Console.WriteLine ("receive result title: " + pushData.title);
			Console.WriteLine ("receive result message: " + pushData.message);
			if (pushData.data != null) 
			{
				Console.WriteLine ("receive result data: " + pushData.data.ToString ());
			}
			Console.WriteLine ("receive result msg id: " + pushData.msgID.ToString());
			Console.WriteLine ("receive result display without dialog: " + pushData.displayWithoutDialog.ToString());
			Console.WriteLine ("receive result is foreground: " + pushData.isAppOnForeground.ToString());
			Console.WriteLine ("receive result badge: " + pushData.badge.ToString());
			Console.WriteLine ("receive result sound: " + pushData.sound);
			Console.WriteLine ("receive result is slide: " + pushData.isInAppSlide.ToString());
			Console.WriteLine ("receive result orientation: " + pushData.orientation.ToString());
			Console.WriteLine ("receive result portion: " + pushData.portion.ToString());
			Console.WriteLine ("receive result speed: " + pushData.speed.ToString());
		}
	}
}

