// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FSStandardLibrary.Core.Checking.ArgumentChecking;
using FSStandardLibrary.Core.Downloader.General;
using FSWeatherInformation.Core.Source;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.WeatherProviders.Base
{
    /// <summary>
    ///     Base class for all weather sources that do not require additional authentication and/or authorization.
    /// </summary>
    public class BaseOpenWeatherProvider
    {
        /// <summary>
        ///     Constructor of class providing access to weather information without additional authentication and/or
        ///     authorization.
        /// </summary>
        /// <param name="downloader">Weather information downloader.</param>
        /// <param name="source">Weather source.</param>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="downloader" /> or <paramref name="source" /> are <c>null</c>.
        /// </exception>
        public BaseOpenWeatherProvider([NotNull] WeatherSource source, [NotNull] IDownloader<string, Uri> downloader)
        {
            NullChecking.ThrowExceptionIfNull(source, nameof(source));
            NullChecking.ThrowExceptionIfNull(downloader, nameof(downloader));
            Source = source;
            Downloader = downloader;
        }

        /// <summary>
        ///     Weather information downloader interface.
        /// </summary>
        [NotNull]
        public IDownloader<string, Uri> Downloader { get; }

        /// <summary>
        ///     Weather information source.
        /// </summary>
        [NotNull]
        public WeatherSource Source { get; }
    }
}