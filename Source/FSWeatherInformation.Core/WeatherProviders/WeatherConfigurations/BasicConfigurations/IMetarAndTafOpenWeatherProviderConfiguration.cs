// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using FSStandardLibrary.Core.Codes;
using FSStandardLibrary.Core.Downloader.General;
using FSWeatherInformation.Core.WeatherProviders.WeatherConfigurations.DownloaderData;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.WeatherProviders.WeatherConfigurations.BasicConfigurations
{
    /// <summary>
    ///     Interface that provides a simple (without additional authentication) configuration
    ///     for downloading METAR and TAF (together) weather reports from a weather information source.
    /// </summary>
    public interface IMetarAndTafOpenWeatherProviderConfiguration : IGetDownloaderDataToDownloadMetarAndTaf<string>
    {
        /// <summary>
        ///     Raw URL-string with fields for further interpolation.
        /// </summary>
        [NotNull]
        string RawStringToDownloadMetarAndTaf { get; }

        /// <summary>
        ///     Forms <see cref="UrlDownloadRequest" /> list by specified ICAO-codes from <paramref name="icaoCodeContainers" />.
        /// </summary>
        /// <param name="icaoCodeContainers">ICAO codes collection.</param>
        /// <returns>List of requests <see cref="UrlDownloadRequest" />.</returns>
        List<UrlDownloadRequest> FormDownloadRequestsForMetarAndTaf(
            [NotNull] IEnumerable<IIcaoCodeContainer> icaoCodeContainers);
    }
}