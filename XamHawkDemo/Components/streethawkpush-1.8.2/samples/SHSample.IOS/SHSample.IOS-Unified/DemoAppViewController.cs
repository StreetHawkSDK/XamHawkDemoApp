using System;
using System.Drawing;

using Foundation;
using UIKit;

using StreethawkIOS.Core;
using StreethawkIOS.Push;

namespace SHSample.IOS
{
	public partial class DemoAppViewController : UIViewController
	{
		public DemoAppViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			RefreshStatus ();

			this.buttonTag.TouchUpInside += delegate(object sender, EventArgs e) {
				bool tagSuccess = SHApp.instance().tagCuid("user_name@mail.com");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagCuid (\"user_name@mail.com\")");
				}
				tagSuccess = SHApp.instance().tagUserLanguage("user language");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagUserLanguage (\"user language\")");
				}
				tagSuccess = SHApp.instance ().tagString ("string_key", "abcdefg");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagString (\"string_key\", \"abcdefg\")");
				}
				tagSuccess = SHApp.instance ().tagNumeric ("numeric_key", 100);
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagNumeric (\"numeric_key\", 100)");
				}
				tagSuccess = SHApp.instance ().tagDatetime ("datetime_key", NSDate.FromTimeIntervalSinceNow(0));
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagDatetime (\"datetime_key\", DateTime.Now)");
				}
				tagSuccess = SHApp.instance ().incrementTag ("numeric_key");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().incrementTag (\"numeric_key\")");
				}
				tagSuccess = SHApp.instance ().incrementTag ("numeric_key", 88);
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().incrementTag (\"numeric_key\", 88)");
				}
				tagSuccess = SHApp.instance ().removeTag ("string_key");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().removeTag (\"string_key\")");
				}
				tagSuccess = SHApp.instance ().tagString ("sh_phone", "+123456");
				if (!tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagString (\"sh_phone\", \"+123456\")");
				}
				tagSuccess = SHApp.instance ().tagString ("sh_phone", "abcdefg");
				if (tagSuccess) 
				{
					Console.WriteLine ("Test fail: SHApp.app ().tagString (\"sh_phone\", \"abcdefg\")");
				}
			};

			this.buttonFeedback.TouchUpInside += delegate {
				SHApp.instance().shSendSimpleFeedback("directly send feedback title", @"send feedback message");
			};

			this.buttonVersion.TouchUpInside += delegate {
				UIAlertView alert = new UIAlertView("StreetHawk SDK version:", SHApp.instance().getSHLibraryVersion, null, "OK", null);
				alert.Show();
			};

			this.buttonInstallId.TouchUpInside += delegate(object sender, EventArgs e) {
				UIAlertView alert = new UIAlertView("Current install id:", SHApp.instance().getInstallId, null, "OK", null);
				alert.Show();
			};

			this.buttonFormattedDatetime.TouchUpInside += delegate(object sender, EventArgs e) {
				string currentTime = SHApp.instance().getCurrentFormattedDateTime();
				UIAlertView alertCurrent = new UIAlertView("Current formatted datetime:", currentTime, null, "OK", null);
				alertCurrent.Show();
				string certainTime = SHApp.instance().getFormattedDateTime(60*60);
				UIAlertView alertCertain = new UIAlertView("1970 formatted datetime:", certainTime, null, "OK", null);
				alertCertain.Show();
			};

			this.buttonEnableNotification.TouchUpInside += delegate(object sender, EventArgs e) {
				SHPush.instance().isNotificationEnabled = !SHPush.instance().isNotificationEnabled;
				RefreshStatus();
			};
		}

		private void RefreshStatus()
		{
			this.buttonEnableNotification.SetTitle(SHPush.instance().isNotificationEnabled ? "Notification Status: Yes" : "Notification Status: No", UIControlState.Normal);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			//trace view enter/exit
			SHApp.instance ().notifyViewEnter (this.GetType ().Name);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			//trace view enter/exit
			SHApp.instance ().notifyViewExit (this.GetType ().Name);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

