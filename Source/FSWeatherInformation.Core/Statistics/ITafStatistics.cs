// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

namespace FSWeatherInformation.Core.Statistics
{
    /// <summary>
    ///     Interface of a class (weather information source mainly) that supports calculation of number of requests for
    ///     getting TAF weather information.
    /// </summary>
    public interface ITafStatistics
    {
        /// <summary>
        ///     number of requests for getting TAF weather information.
        /// </summary>
        /// <remarks>Only valid request cases are considered, i.e. cases with valid ICAO codes.</remarks>
        int NumberOfRequestsToDownloadTaf { get; }
    }
}