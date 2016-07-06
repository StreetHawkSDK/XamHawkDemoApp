using System;
namespace XamHawkDemo
{
	public interface IStreetHawkLocations
	{
		/// <summary>
		/// Starts the location reporting.
		/// </summary>
		/// <returns>The location reporting.</returns>
		void StartLocationReporting();

		/// <summary>
		/// Stops the location reporting.
		/// </summary>
		/// <returns>The location reporting.</returns>
		void StopLocationReporting();


		/// <summary>
		/// Reports the work home locations only.
		/// </summary>
		/// <returns>The work home locations only.</returns>
		void ReportWorkHomeLocationsOnly();


		/// <summary>
		/// Updates the location monitoring parameters.
		/// </summary>
		/// <returns>The location monitoring parameters.</returns>
		/// <param name="UPDATE_INTERVAL_FG">Update interval fg.</param>
		/// <param name="UPDATE_DISTANCE_FG">Update distance fg.</param>
		/// <param name="UPDATE_INTERVAL_BG">Update interval background.</param>
		/// <param name="UPDATE_DISTANCE_BG">Update distance background.</param>
		void updateLocationMonitoringParams(int UPDATE_INTERVAL_FG, int UPDATE_DISTANCE_FG, int UPDATE_INTERVAL_BG, int UPDATE_DISTANCE_BG);
	}
}

