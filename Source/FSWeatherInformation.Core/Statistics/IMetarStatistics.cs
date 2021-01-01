// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

namespace FSWeatherInformation.Core.Statistics
{
    /// <summary>
    ///     Interface of a class (weather information source mainly) that supports calculation of number of requests for
    ///     getting METAR weather information.
    /// </summary>
    public interface IMetarStatistics
    {
        /// <summary>
        ///     Number of requests for getting METAR weather information.
        /// </summary>
        /// <remarks>Only valid request cases are considered, i.e. cases with valid ICAO codes.</remarks>
        int NumberOfRequestsToDownloadMetar { get; }
    }
}