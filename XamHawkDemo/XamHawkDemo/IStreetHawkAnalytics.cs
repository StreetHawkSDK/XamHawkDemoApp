using System;
namespace XamHawkDemo
{
	public delegate void OnInstallRegisteredCallback(string installId);
	public interface IStreetHawkAnalytics
	{

		/// <summary>
		/// Sets the app key.
		/// </summary>
		/// <returns>The app key.</returns>
		/// <param name="appKey">App key.</param>
		void SetAppKey(string appKey);

		/// <summary>
		/// Init StreeHawk
		/// </summary>
		void Init();

		/// <summary>
		/// Gets the app key.
		/// </summary>
		/// <returns>The app key.</returns>
		string GetAppKey();

		/// <summary>
		/// Gets the SHL ibrary version.
		/// </summary>
		/// <returns>The StreetHawk's library version.</returns>
		string GetSHLibraryVersion();

		/// <summary>
		/// Tags the user language.
		/// </summary>
		/// <returns>The user language.</returns>
		void TagUserLanguage(string language);


		/// <summary>
		/// Displaies the badge. Note that for Android, the API depends on home screen launcher and badge wont be displayed on non supported devices.
		/// </summary>
		/// <returns>The badge.</returns>
		/// <param name="badgeCount">Badge count.</param>
		void DisplayBadge(int badgeCount);

		/// <summary>
		/// Notifies the view entered by the user.
		/// </summary>
		/// <returns>The view enter.</returns>
		/// <param name="viewName">View name.</param>
		void NotifyViewEnter(string viewName);

		/// <summary>
		/// Notifies the view exit.
		/// </summary>
		/// <returns>The view exit.</returns>
		/// <param name="viewName">View name.</param>
		void NotifyViewExit(string viewName);


		/// <summary>
		/// Sends the simple feedback.
		/// </summary>
		/// <returns>The simple feedback.</returns>
		/// <param name="title">Title for the feedback.</param>
		/// <param name="message">Message for the feedback.</param>
		void SendSimpleFeedback(string title, string message);

		/// <summary>
		/// Tags user's unique identifier.
		/// </summary>
		/// <returns>The cuid.</returns>
		/// <param name="cuid">Cuid.</param>
		void TagCuid(string cuid);


		/// <summary>
		/// Tags numeric event inside the app.
		/// </summary>
		/// <returns>The numeric.</returns>
		/// <param name="key">Key for the event.</param>
		/// <param name="value">Value for the venet.</param>
		void TagNumeric(string key, double value);

		/// <summary>
		/// Tags string event inside the app.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="key">Key for the event.</param>
		/// <param name="value">Value for the event.</param>
		void TagString(string key, string value);

		/// <summary>
		/// Tags datetime event for the app.
		/// </summary>
		/// <returns>The date time.</returns>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		void TagDateTime(string key, string value);

		/// <summary>
		/// Increment the value of a previous tag by 1. If the tag is not present then API will create the Tag with value 1.
		/// </summary>
		/// <returns>The tag.</returns>
		/// <param name="key">Key.</param>
		void IncrementTag(string key);

		/// <summary>
		/// Increments the tag with given value.  If the tag is not present then API will create the Tag with value given.
		/// </summary>
		/// <returns>The tag.</returns>
		/// <param name="key">Key.</param>
		/// <param name="incrValue">Incr value.</param>
		void IncrementTag(string key, int incrValue);

		/// <summary>
		/// Removes the tag from StreetHawk server.
		/// </summary>
		/// <returns>The tag.</returns>
		/// <param name="key">Key.</param>
		void RemoveTag(string key);

		/// <summary>
		/// Gets the current formatted date time.
		/// </summary>
		/// <returns>The current formatted date time.</returns>
		string GetCurrentFormattedDateTime();

		/// <summary>
		/// Gets the formatted date time for given time in milies.
		/// </summary>
		/// <returns>The formatted date time.</returns>
		/// <param name="time">Time.</param>
		string GetFormattedDateTime(long time);

		/// <summary>
		/// Gets the install id for the install in StreetHawk.
		/// </summary>
		/// <returns>The install identifier.</returns>
		string GetInstallId();

		/*iOS only functions*/


		/*Android only functions*/

		/// <summary>
		/// Sets the advertisement identifier.
		/// </summary>
		/// <returns>The advertisement identifier.</returns>
		void SetAdvertisementId(string id);

		/// <summary>
		/// Callback function which will be called when install is successfully registered with StreetHawk server.
		/// </summary>
		/// <returns>Name of callback function.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForInstallEvent(OnInstallRegisteredCallback cb);

		void DisplayLog(string tag, string logline);

	}
}

