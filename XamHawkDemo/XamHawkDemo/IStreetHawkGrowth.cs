using System;
namespace XamHawkDemo
{

	/// <summary>
	/// Register for callback to receive share url from StreetHawk which can be shared with friends
	/// </summary>
	public delegate void RegisterForShareURLCallback(string url);

	/// <summary>
	/// Register for callback to receive erros while generating share url
	/// </summary>
	public delegate void RegisterForErrorForShareURLCallback();

	/// <summary>
	/// Register for callback to receive deeplink url for differed deeplinking in cross platforms
	/// </summary>
	public delegate void RegisterForDeeplinkURLCallback(string url);

	public interface IStreetHawkGrowth
	{
		
		/// <summary>
		/// Registers for error for share URL.
		/// </summary>
		/// <returns>The for error for share URL.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForErrorForShareURL(RegisterForErrorForShareURLCallback cb);

		/// <summary>
		/// Registers for deeplink URL.
		/// </summary>
		/// <returns>The for deeplink URL.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForDeeplinkURL(RegisterForDeeplinkURLCallback cb);

		/// <summary>
		/// Adds the growth module.
		/// </summary>
		/// <returns>The growth module.</returns>
		void AddGrowthModule();

		/// <summary>
		/// Gets the share URL for app download.
		/// </summary>
		/// <returns>The share URL for app download.</returns>
		/// <param name="utm_campaign">Utm campaign.</param>
		/// <param name="share_url">Share URL.</param>
		/// <param name="useDefaultDialog">Use default dialog.</param>
		void GetShareUrlForAppDownload(string utm_campaign, string share_url, RegisterForShareURLCallback cb);

		/// <summary>
		/// Gets the share URL for app download.
		/// </summary>
		/// <returns>The share URL for app download.</returns>
		/// <param name="utm_campaign">Utm campaign.</param>
		/// <param name="deeplink_uri">Deeplink URI.</param>
		/// <param name="utm_source">Utm source.</param>
		/// <param name="utm_medium">Utm medium.</param>
		/// <param name="utm_term">Utm term.</param>
		/// <param name="campaign_content">Campaign content.</param>
		/// <param name="default_url">Default URL.</param>
		/// <param name="useDefaultDialog">Use default dialog.</param>
		void GetShareUrlForAppDownload(string utm_campaign, string deeplink_uri, string utm_source, string utm_medium, string utm_term,
									   string campaign_content, String default_url, RegisterForShareURLCallback cb);

	}
}

