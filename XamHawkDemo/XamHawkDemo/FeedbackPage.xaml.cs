using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage()
		{
			InitializeComponent();
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

		private void buttonSubmitClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTitle.Text))
			{
				DisplayAlert("Please input title.", "Title is mandatory for feedback.", "OK");
				return;
			}
			DependencyService.Get<IStreetHawkAnalytics>().SendSimpleFeedback(this.textboxTitle.Text, this.textboxMessage.Text);
		}
	}
}

