using System;
namespace XamHawkDemo
{
	public delegate void RegisterForShReceivedRawJSONCallback(string title,string message,string JSON);
	public delegate void RegisterForShNotifyAppPageCallback(string appPage);
	public delegate void RegisterForOnReceivePushDataCallback();  //TODO
	public delegate void RegisterForOnReceiveResultCallback();    //TODO
	public delegate void RegisterForOnReceiveNonSHPushPayloadCallback(); //TODO

	public interface IStreetHawkPush
	{

		/// <summary>
		/// Forces the push to notification bar.
		/// </summary>
		/// <returns>The push to notification bar.</returns>
		/// <param name="status">Status.</param>
		void ForcePushToNotificationBar(bool status);

		/// <summary>
		/// Returns true if device is using push notifications else false.
		/// </summary>
		/// <returns>The use push.</returns>
		bool IsUsePush();

		/// <summary>
		/// Set to true if you wish to display customised dialog for push notifications
		/// </summary>
		/// <returns>The use custom dialog.</returns>
		/// <param name="answer">Answer.</param>
		void setUseCustomDialog(bool answer);

		/// <summary>
		/// Registers for raw json.
		/// </summary>
		/// <returns>The for raw json.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForRawJSON(RegisterForShReceivedRawJSONCallback cb);

		/// <summary>
		/// Shs the notify app page.
		/// </summary>
		/// <returns>The notify app page.</returns>
		/// <param name="cb">Cb.</param>
		void ShNotifyAppPage(RegisterForShNotifyAppPageCallback cb);

		/// <summary>
		/// Ons the receive push data.
		/// </summary>
		/// <returns>The receive push data.</returns>
		/// <param name="cb">Cb.</param>
		void OnReceivePushData(RegisterForOnReceivePushDataCallback cb);

		/// <summary>
		/// Ons the receive result.
		/// </summary>
		/// <returns>The receive result.</returns>
		/// <param name="cb">Cb.</param>
		void OnReceiveResult(RegisterForOnReceiveResultCallback cb);

		/// <summary>
		/// Ons the receive non SHP ush payload.
		/// </summary>
		/// <returns>The receive non SHP ush payload.</returns>
		/// <param name="cb">Cb.</param>
		void OnReceiveNonSHPushPayload(RegisterForOnReceiveNonSHPushPayloadCallback cb);

		/// <summary>
		/// Sends the push result. 1 for accepted, -1 for decline and 0 for later
		/// </summary>
		/// <returns>The push result.</returns>
		/// <param name="result">Result.</param>
		void SendPushResult(string msgid, int result);

		/// <summary>
		/// Get remaining time in minutes till user won't receive push notification
		/// </summary>
		/// <returns>The alert settings.</returns>
		int GetAlertSettings();

		/// <summary>
		/// Set in minutes time for which user won't be disturbed with push notification
		/// </summary>
		/// <returns>The alert settings.</returns>
		void SetAlertSettings(int minutes);

		/// <summary>
		/// Gets the name of the page which app should display when lauched via deeplink or push message
		/// </summary>
		/// <returns>The app page.</returns>
		string GetAppPage();

		/// <summary>
		/// Get the identifier for a given icon
		/// </summary>
		/// <returns>The icon.</returns>
		/// <param name="iconName">Icon name.</param>
		int GetIcon(string iconName);

		//TODO
		void GetButtinPairFromId();

		//TODO
		void SetInteractivePushBtnPairs();

		/*Android Only*/
		/// <summary>
		/// Registers for push messaging by passing project number as received from StreetHawk server.
		/// </summary>
		/// <returns>The for push messaging.</returns>
		/// <param name="projectNumber">Project number.</param>
		void RegisterForPushMessaging(string projectNumber);

		/// <summary>
		/// Adds the push module. if you are updating push module after StreetHawk has been initialised
		/// </summary>
		/// <returns>The push module.</returns>
		void AddPushModule();

	}
}

