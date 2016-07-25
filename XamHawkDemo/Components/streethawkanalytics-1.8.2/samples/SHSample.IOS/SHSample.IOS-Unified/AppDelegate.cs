using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;

using StreethawkIOS.Core;

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
}

