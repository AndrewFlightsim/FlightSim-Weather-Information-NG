// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FSStandardLibrary.Core.Codes;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.WeatherProviders.WeatherConfigurations.DownloaderData
{
    /// <summary>
    ///     Interface of object that provides the data required to download METAR and TAF meteorological reports to downloader.
    /// </summary>
    /// <typeparam name="T">Data type for downloader to work with. </typeparam>
    public interface IGetDownloaderDataToDownloadMetarAndTaf<out T>
    {
        /// <summary>
        ///     Provides the data required to download METAR and TAF meteorological reports (together) of the specified ICAO code (
        ///     <paramref name="icaoCodeContainer" />) to downloader.
        /// </summary>
        /// <param name="icaoCodeContainer">
        ///     Class containing the ICAO code of the airport for which to download weather information reports.
        /// </param>
        /// <returns>Data type <typeparamref name="T" /> that is used by downloader to work with.</returns>
        [NotNull]
        T GetDownloaderDataToDownloadMetarAndTaf([NotNull] IIcaoCodeContainer icaoCodeContainer);
    }
}