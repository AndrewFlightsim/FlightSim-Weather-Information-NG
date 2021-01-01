// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Threading.Tasks;
using FSStandardLibrary.Core.Codes;
using FSWeatherInformation.Core.Statistics;
using FSWeatherInformation.Core.WeatherStrings;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.ServiceTypes
{
    /// <summary>
    ///     Interface of weather provider that allows asynchronous downloading of <see cref="MetarString" /> weather
    ///     information.
    /// </summary>
    public interface IMetarStringProvider : IMetarStatistics
    {
        /// <summary>
        ///     Asynchronously downloads weather information of category <see cref="MetarString" /> for specified ICAO code.
        /// </summary>
        /// <param name="icaoCodeContainer">
        ///     Class that contain ICAO code of airport to download weather information.
        /// </param>
        /// <returns>Task to download <see cref="MetarString" /> weather information.</returns>
        [NotNull]
        Task<MetarString> DownloadMetarStringAsync([NotNull] IIcaoCodeContainer icaoCodeContainer);

        /// <summary>
        ///     Asynchronously downloads weather information of category <see cref="MetarString" /> for specified ICAO codes.
        /// </summary>
        /// <param name="icaoCodeContainers">
        ///     Collection of classes that contain ICAO codes of airports to download weather information.
        /// </param>
        /// <returns>
        ///     Task to download the list of < see cref="List {T} " /> weather information elements according to
        ///     specified ICAO codes of airports, where <c> T </c> - < see cref="MetarString " />.
        /// </returns>
        [NotNull]
        Task<List<MetarString>> DownloadSeveralMetarStringsAsync(
            [NotNull] IReadOnlyList<IIcaoCodeContainer> icaoCodeContainers);
    }
}