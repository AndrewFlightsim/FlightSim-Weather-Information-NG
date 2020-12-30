// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Runtime.CompilerServices;
using FSStandardLibrary.Core.Checking.ArgumentChecking;
using FSStandardLibrary.Core.Codes;
using FSStandardLibrary.Core.Hashing;
using FSWeatherInformation.Core.Source;
using JetBrains.Annotations;

#endregion

[assembly: InternalsVisibleTo("WeatherInformationNG.UnitTests")]

namespace FSWeatherInformation.Core.WeatherStrings.Base
{
    /// <summary>
    ///     Base class for weather information strings (for example <see cref="MetarString" />,  <see cref="TafString" />).
    /// </summary>
    public class WeatherString : IIcaoCodeContainer, IEquatable<WeatherString>
    {
        /// <summary>
        ///     Weather string constructor.
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
        protected internal WeatherString([NotNull] IcaoCode icaoCode, string _string, bool found, WeatherSource source)
        {
            NullChecking.ThrowExceptionIfNull(icaoCode, nameof(icaoCode));
            NullChecking.ThrowExceptionIfNull(source, nameof(source));
            if (found)
            {
                StringArgumentChecking.ThrowExceptionIfStringIsInvalid(_string, nameof(_string));
                String = StringArgumentChecking.IsStringValid(_string)
                    ? _string
                    : $"Not found for airport with ICAO code {icaoCode.Code}";
            }
            else
            {
                String = $"Not found for airport with ICAO code {icaoCode.Code}";
            }

            AirportIcaoCode = icaoCode;
            Found = found;
            Source = source;
        }

        /// <summary>
        ///     Was information found.
        /// </summary>
        public bool Found { get; }

        /// <summary>
        ///     Weather information string source of type <see cref="WeatherSource" />.
        /// </summary>
        public WeatherSource Source { get; }

        /// <summary>
        ///     Weather string in normalized (standard) representation.
        /// </summary>
        [NotNull]
        public string String { get; }

        #region Implementation of IEquatable<WeatherString>

        /// <inheritdoc />
        public bool Equals(WeatherString other)
        {
            return other != null
                   && other.Found == Found
                   && other.Source.Equals(Source)
                   && other.AirportIcaoCode.Equals(AirportIcaoCode)
                   && other.String == String;
        }

        #endregion

        /// <summary>
        ///     Airport ICAO code to which this weather string belongs.
        /// </summary>
        [NotNull]
        public IcaoCode AirportIcaoCode { get; }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Source.Name} => {String}";
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as WeatherString);
        }

        /// <summary>
        ///     Custom hash function.
        /// </summary>
        /// <returns>Hash code of current object.</returns>
        public override int GetHashCode()
        {
            return CustomHash
                .GetInitialHashNumber()
                .AddToHashNumber(String.GetHashCode())
                .AddToHashNumber(Found.GetHashCode())
                .AddToHashNumber(Source.GetHashCode())
                .AddToHashNumber(AirportIcaoCode.GetHashCode())
                .AddToHashNumber(nameof(WeatherString).GetHashCode());
        }

        #endregion
    }
}