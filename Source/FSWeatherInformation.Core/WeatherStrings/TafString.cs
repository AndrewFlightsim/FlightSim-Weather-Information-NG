// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FSStandardLibrary.Core.Codes;
using FSWeatherInformation.Core.Source;
using FSWeatherInformation.Core.WeatherStrings.Base;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.WeatherStrings
{
    /// <summary>
    ///     Class representing TAF weather string.
    /// </summary>
    public sealed class TafString : WeatherString
    {
        /// <summary>
        ///     TAF weather string constructor.
        /// </summary>
        /// <param name="icaoCode">Airport ICAO code to which this weather string belongs.</param>
        /// <param name="_string">Weather string in normalized (standard) representation.</param>
        /// <param name="found">Was information string found.</param>
        /// <param name="source">Weather information string source of type <see cref="WeatherSource" />.</param>
        /// <exception cref="ArgumentException">
        ///     If <paramref name="_string" /> is not a valid string but <paramref name="found" /> is <c>true</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="icaoCode" /> or <paramref name="source" /> are <c>null</c>.
        /// </exception>
        public TafString([NotNull] IcaoCode icaoCode, string _string, bool found, WeatherSource source) :
            base(icaoCode, Normalizer.Normalizer.GetNormalizedTafStringFrom(found, _string, icaoCode), found, source)
        {
        }
    }
}