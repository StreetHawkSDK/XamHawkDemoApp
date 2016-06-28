using Android.App;
using Android.Widget;
using Android.OS;
using Com.Streethawk.Library.Core;

namespace XamHawkAnalytics
{
	[Activity (Label = "XamHawkAnalytics", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
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

				//Sample code Tagging cuid

				string cuid = "support@streethawk.com";
				StreetHawk.Instance.TagCuid(cuid);

			};
		}
	}
}
