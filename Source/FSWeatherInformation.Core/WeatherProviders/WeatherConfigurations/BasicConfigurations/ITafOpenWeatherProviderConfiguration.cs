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
    ///     for downloading TAF weather report from a weather information source.
    /// </summary>
    public interface ITafOpenWeatherProviderConfiguration : IGetDownloaderDataToDownloadTaf<string>
    {
        /// <summary>
        ///     Raw URL-string with fields for further interpolation.
        /// </summary>
        [NotNull]
        string RawStringToDownloadTaf { get; }

        /// <summary>
        ///     Forms <see cref="UrlDownloadRequest" /> list by specified ICAO-codes from <paramref name="icaoCodeContainers" />.
        /// </summary>
        /// <param name="icaoCodeContainers">ICAO codes collection.</param>
        /// <returns>List of requests <see cref="UrlDownloadRequest" />.</returns>
        [NotNull]
        List<UrlDownloadRequest> FormDownloadRequestsForTaf(
            [NotNull] IEnumerable<IIcaoCodeContainer> icaoCodeContainers);
    }
}