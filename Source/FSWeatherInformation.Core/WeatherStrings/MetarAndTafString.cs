// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FSStandardLibrary.Core.Checking.ArgumentChecking;
using FSStandardLibrary.Core.Hashing;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.WeatherStrings
{
    /// <summary>
    ///     Class representing METAR and TAF strings together.
    /// </summary>
    public sealed class MetarAndTafString : IEquatable<MetarAndTafString>
    {
        /// <summary>
        ///     Constructor from METAR and TAF weather information.
        /// </summary>
        /// <param name="metarString">METAR weather information string.</param>
        /// <param name="tafString">TAF weather information string.</param>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="metarString" /> or <paramref name="tafString" /> are <c>null</c>.
        /// </exception>
        public MetarAndTafString([NotNull] MetarString metarString, [NotNull] TafString tafString)
        {
            NullChecking.ThrowExceptionIfNull(metarString, nameof(metarString));
            NullChecking.ThrowExceptionIfNull(tafString, nameof(tafString));

            MetarString = metarString;
            TafString = tafString;
        }

        /// <summary>
        ///     METAR weather information string.
        /// </summary>
        [NotNull]
        public MetarString MetarString { get; }

        /// <summary>
        ///     TAF weather information string.
        /// </summary>
        [NotNull]
        public TafString TafString { get; }

        /// <summary>
        ///     Implicit conversion operator from <see cref="MetarAndTafString" /> to <see cref="WeatherStrings.MetarString" />.
        /// </summary>
        /// <param name="metarAndTafString">
        ///     <see cref="MetarAndTafString" /> object for converting to
        ///     <see cref="WeatherStrings.MetarString" />
        /// </param>
        public static implicit operator MetarString(MetarAndTafString metarAndTafString)
        {
            return metarAndTafString.MetarString;
        }

        /// <summary>
        ///     Implicit conversion operator from <see cref="MetarAndTafString" /> to <see cref="WeatherStrings.TafString" />.
        /// </summary>
        /// <param name="metarAndTafString">
        ///     <see cref="MetarAndTafString" /> object for converting to
        ///     <see cref="WeatherStrings.TafString" />
        /// </param>
        public static implicit operator TafString(MetarAndTafString metarAndTafString)
        {
            return metarAndTafString.TafString;
        }

        #region Implementation of IEquatable<MetarAndTafString>

        /// <inheritdoc />
        public bool Equals(MetarAndTafString other)
        {
            return other != null
                   && MetarString.Equals(other.MetarString)
                   && TafString.Equals(other.TafString);
        }

        #endregion

        #region Overrides of Object

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as MetarAndTafString);
        }

        /// <summary>
        ///     Custom hash function.
        /// </summary>
        /// <returns>Hash code of current object.</returns>
        public override int GetHashCode()
        {
            return CustomHash.GetInitialHashNumber()
                .AddToHashNumber(MetarString.GetHashCode())
                .AddToHashNumber(TafString.GetHashCode())
                .AddToHashNumber(nameof(MetarAndTafString).GetHashCode());
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{MetarString}\n{TafString}";
        }

        #endregion
    }
}