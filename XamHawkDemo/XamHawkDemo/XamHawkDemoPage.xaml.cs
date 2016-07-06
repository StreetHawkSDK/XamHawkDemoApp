using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class XamHawkDemoPage : ContentPage
	{
		public XamHawkDemoPage()
		{
			InitializeComponent();

			var listView = new ListView
			{
				RowHeight = 50
			};
			listView.ItemsSource = new string[]
			{
				"Analytics", "Growth", "Push", "Beacons", "Geofence", "Locations", "Feeds", "Feedback", "Install-Info",
			};
			listView.ItemTapped += async (sender, e) =>
			{
				if (e.Item.ToString() == "Analytics")
				{
					await Navigation.PushAsync(new AnalyticsPage());
				}
				else if (e.Item.ToString() == "Growth")
				{
					await Navigation.PushAsync(new GrowthPage());
				}
				else if (e.Item.ToString() == "Push")
				{
					await Navigation.PushAsync(new PushPage());
				}
				else if (e.Item.ToString() == "Beacons")
				{
					await Navigation.PushAsync(new BeaconsPage());
				}
				else if (e.Item.ToString() == "Geofence")
				{
					await Navigation.PushAsync(new GeofencePage());
				}
				else if (e.Item.ToString() == "Locations")
				{
					await Navigation.PushAsync(new LocationsPage());
				}
				else if (e.Item.ToString() == "Feeds")
				{
					await Navigation.PushAsync(new FeedsPage());
				}
				else if (e.Item.ToString() == "Feedback")
				{
					await Navigation.PushAsync(new FeedbackPage());
				}
				else if (e.Item.ToString() == "Install-Info")
				{
					await Navigation.PushAsync(new InstallInfoPage());
				}
			};
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewEnter(this.GetType().Name);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			DependencyService.Get<IStreetHawkAnalytics>().NotifyViewExit(this.GetType().Name);
		}
	}
}

