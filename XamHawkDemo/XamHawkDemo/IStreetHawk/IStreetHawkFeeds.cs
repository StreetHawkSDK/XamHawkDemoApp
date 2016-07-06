using System;
namespace XamHawkDemo
{
	public delegate void RegisterForFeedCallback();
	public interface IStreetHawkFeeds
	{
		/// <summary>
		/// Send acknowledgement for a feed item.
		/// </summary>
		/// <returns>The feed ack.</returns>
		/// <param name="feedid">Feedid.</param>
		void SendFeedAck(int feedid);

		/// <summary>
		/// Notifies user's action on feed item. 1 for accepted, 0 for later and -1 for decline
		/// </summary>
		/// <returns>The feed result.</returns>
		/// <param name="feedid">Feedid.</param>
		/// <param name="result">Result.</param>
		void NotifyFeedResult(int feedid, int result);

		/// <summary>
		/// Fetch feed data from StreetHawk server
		/// </summary>
		/// <returns>The feed data.</returns>
		/// <param name="offset">Offset.</param>
		void ReadFeedData(int offset);

		/// <summary>
		/// Registers for feeds.
		/// </summary>
		/// <returns>The for feeds.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForFeeds(RegisterForFeedCallback cb);
	}
}

