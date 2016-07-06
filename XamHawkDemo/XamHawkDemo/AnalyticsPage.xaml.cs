using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StreetHawkCrossplatform;

namespace XamHawkDemo
{
	public partial class AnalyticsPage : ContentPage
	{
		public AnalyticsPage()
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

		private void buttonTagKeyValueClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTagKey.Text))
			{
				DisplayAlert("Please input key.", "Key of tag is mandatory.", "OK");
				return;
			}
			if (string.IsNullOrEmpty(this.textboxTagValue.Text))
			{
				DisplayAlert("Please input value.", "Value of tag is mandatory.", "OK");
				return;
			}
			DateTime datetime = DateTime.MinValue;
			if (DateTime.TryParse(this.textboxTagValue.Text, out datetime))
			{
				DependencyService.Get<IStreetHawkAnalytics>().TagDateTime(this.textboxTagKey.Text, datetime);
				DisplayAlert("Tag datetime successfully.", "A datetime tag is sent to server.", "OK");
				return;
			}
			double numeric = 0;
			if (!string.Equals(this.textboxTagKey.Text, "sh_phone") && double.TryParse(this.textboxTagValue.Text, out numeric))
			{
				DependencyService.Get<IStreetHawkAnalytics>().TagNumeric(this.textboxTagKey.Text, numeric);
				DisplayAlert("Tag numeric successfully.", "A numeric tag is sent to server.", "OK");
				return;
			}
			if (datetime == DateTime.MinValue && numeric == 0)
			{
				DependencyService.Get<IStreetHawkAnalytics>().TagString(this.textboxTagKey.Text, this.textboxTagValue.Text);
				DisplayAlert("Tag string successfully.", "A string tag is sent to server.", "OK");
				return;
			}
			DisplayAlert("Fail to tag.", "Check console log or contact your support.", "OK");
		}

		private void buttonTagCuidClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTagCuid.Text))
			{
				DisplayAlert("Please input cuid.", "Cuid value is mandatory.", "OK");
				return;
			}
			DependencyService.Get<IStreetHawkAnalytics>().TagCuid(this.textboxTagCuid.Text);
			DisplayAlert("Tag cuid successfully.", "A sh_cuid tag is sent to server.", "OK");
		}

		private void buttonTagLanguageClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTagLanguage.Text))
			{
				DisplayAlert("Please input language.", "Language value is mandatory.", "OK");
				return;
			}
			DependencyService.Get<IStreetHawkAnalytics>().TagUserLanguage(this.textboxTagLanguage.Text);
			DisplayAlert("Tag language successfully.", "A sh_language tag is sent to server.", "OK");
		}

		private void buttonTagIncrementClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTagIncrementKey.Text))
			{
				DisplayAlert("Please input key.", "Key of increment tag is mandatory.", "OK");
				return;
			}
			int number = 0;
			if (int.TryParse(this.textboxTagIncrementValue.Text, out number))
			{
				DependencyService.Get<IStreetHawkAnalytics>().IncrementTag(this.textboxTagIncrementKey.Text, number);
				DisplayAlert("Increment tag successfully.", string.Format("Tag {0} increment {1}.", this.textboxTagIncrementKey.Text, number), "OK");
			}
			else
			{
				DependencyService.Get<IStreetHawkAnalytics>().IncrementTag(this.textboxTagIncrementKey.Text);
				DisplayAlert("Increment tag successfully.", string.Format("Tag {0} increment 1.", this.textboxTagIncrementKey.Text), "OK");
			}
		}

		private void buttonTagDeleteClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textboxTagDeleteKey.Text))
			{
				DisplayAlert("Please input key.", "Key of delete tag is mandatory.", "OK");
				return;
			}
			DependencyService.Get<IStreetHawkAnalytics>().RemoveTag(this.textboxTagDeleteKey.Text);
			DisplayAlert("Delete tag successfully.", string.Format("Tag {0} is deleted.", this.textboxTagDeleteKey.Text), "OK");
		}
	}
}

