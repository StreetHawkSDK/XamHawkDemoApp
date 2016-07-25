using Android.App;
using Android.Widget;
using Android.OS;
using Com.Streethawk.Library.Growth;
using Com.Streethawk.Library.Core;
using Org.Json;

// Add for deeplinking
using Android.Content;

namespace XamGrowth
{
	// Add for deeplinking
	[Activity (Label = "XamGrowth", MainLauncher = true, Icon = "@mipmap/icon")]
	[IntentFilter (new[]{Intent.ActionView},
		Categories=new[]{Intent.CategoryLauncher,Intent.CategoryBrowsable,Intent.CategoryDefault},
		Icon="@mipmap/icon",
		DataScheme="shsample", // define scheme here
		DataHost="setparams")] // define host here
	

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

			StreetHawk.Instance.NotifyViewEnter ("Name");
			StreetHawk.Instance.NotifyViewExit ("Name");


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
			Android.Util.Log.Info ("StreetHawk", "Share Url " + shareUrl);
		}

	
    
		public void OnReceiveErrorForShareUrl(JSONObject errorResponse){
		
		
		}

		public void OnReceiveDeepLinkUrl(string deeplinkurl){
			
		}
			
	}
}
