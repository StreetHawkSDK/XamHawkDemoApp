// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SHSample.IOS
{
	[Register ("DemoAppViewController")]
	partial class DemoAppViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonFeedback { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonFormattedDateTime { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonInstallId { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonTag { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonVersion { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (buttonFeedback != null) {
				buttonFeedback.Dispose ();
				buttonFeedback = null;
			}
			if (buttonFormattedDateTime != null) {
				buttonFormattedDateTime.Dispose ();
				buttonFormattedDateTime = null;
			}
			if (buttonInstallId != null) {
				buttonInstallId.Dispose ();
				buttonInstallId = null;
			}
			if (buttonTag != null) {
				buttonTag.Dispose ();
				buttonTag = null;
			}
			if (buttonVersion != null) {
				buttonVersion.Dispose ();
				buttonVersion = null;
			}
		}
	}
}
