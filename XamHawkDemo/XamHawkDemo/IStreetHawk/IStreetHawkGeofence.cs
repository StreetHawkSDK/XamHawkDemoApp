using System;
namespace XamHawkDemo
{
	public delegate void RegisterGeofenceEnterCallback();
	public delegate void RegisterGeofenceExitCallback();
	public interface IStreetHawkGeofence
	{
		/// <summary>
		/// Registers for geofence enter.
		/// </summary>
		/// <returns>The for geofence enter.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForGeofenceEnter(RegisterGeofenceEnterCallback cb);

		/// <summary>
		/// Registers for geofence exit.
		/// </summary>
		/// <returns>The for geofence exit.</returns>
		/// <param name="cb">Cb.</param>
		void RegisterForGeofenceExit(RegisterGeofenceExitCallback cb);

		/// <summary>
		/// Stops the monitoring.
		/// </summary>
		/// <returns>The monitoring.</returns>
		void StopGeofenceMonitoring();

		/// <summary>
		/// Starts the geofence monitoring.
		/// </summary>
		/// <returns>The geofence monitoring.</returns>
		void StartGeofenceMonitoring();

		/// <summary>
		/// Gets the geofence entered list.
		/// </summary>
		/// <returns>The geofence entered list.</returns>
		//TODO
		//void GetGeofenceEnteredList();

		/// <summary>
		/// Gets the geofence exit list.
		/// </summary>
		/// <returns>The geofence exit list.</returns>
		//TODO
		//void GetGeofenceExitList();
	}
}

