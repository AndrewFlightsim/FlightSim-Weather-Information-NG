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
    ///     Interface of weather provider that allows asynchronous downloading of <see cref="TafString" /> weather information.
    /// </summary>
    public interface ITafStringProvider : ITafStatistics
    {
        /// <summary>
        ///     Asynchronously downloads weather information of category <see cref="TafString" /> for specified ICAO codes.
        /// </summary>
        /// <param name="icaoCodeContainers">
        ///     Collection of classes that contain ICAO codes of airports to download weather information.
        /// </param>
        /// <returns>
        ///     Task to download the list of < see cref="List {T} " /> weather information elements according to
        ///     specified ICAO codes of airports, where <c> T </c> - < see cref="TafString " />.
        /// </returns>
        [NotNull]
        Task<List<TafString>> DownloadSeveralTafStringsAsync(
            [NotNull] IReadOnlyList<IIcaoCodeContainer> icaoCodeContainers);

        /// <summary>
        ///     Asynchronously downloads weather information of category <see cref="TafString" /> for specified ICAO code.
        /// </summary>
        /// <param name="icaoCodeContainer">
        ///     Class that contain ICAO code of airport to download weather information.
        /// </param>
        /// <returns>Task to download <see cref="TafString" /> weather information.</returns>
        [NotNull]
        Task<TafString> DownloadTafStringAsync([NotNull] IIcaoCodeContainer icaoCodeContainer);
    }
}