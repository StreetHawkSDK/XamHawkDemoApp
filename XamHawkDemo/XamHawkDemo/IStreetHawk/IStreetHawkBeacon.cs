using System;
namespace XamHawkDemo
{
	public delegate void RegisterForBeaconCallback();
	public interface IStreetHawkBeacon
	{
		/// <summary>
		/// Registers for beacon status.
		/// </summary>
		/// <returns>The for beacon status.</returns>
		void RegisterForBeaconStatus(RegisterForBeaconCallback cb);

		/// <summary>
		/// Notify beacon enter if you are using a third party library to detect beacons
		/// </summary>
		/// <returns>The enter beacon.</returns>
		/// <param name="uuid">UUID.</param>
		/// <param name="major">Major. Major number of detected beacon</param>
		/// <param name="minor">Minor. Minor number of detected beacon</param>
		/// <param name="distance">Distance. Distance between beaocn and device</param>
		int ShEnterBeacon(string uuid, int major, int minor, double distance);

		/// <summary>
		/// Notify beacon exit if you are using a third party library to detect beaocn exits
		/// </summary>
		/// <returns>The exit beacon.</returns>
		/// <param name="uuid">UUID.</param>
		/// <param name="major">Major.</param>
		/// <param name="minor">Minor.</param>
		int ShExitBeacon(string uuid, int major, int minor);

		/// <summary>
		/// Stops the beacon monitoring.
		/// </summary>
		/// <returns>The beacon monitoring.</returns>
		void StopBeaconMonitoring();

		/// <summary>
		/// Starts the beacon monitoring.
		/// </summary>
		/// <returns>The beacon monitoring.</returns>
		void StartBeaconMonitoring();
	}
}

