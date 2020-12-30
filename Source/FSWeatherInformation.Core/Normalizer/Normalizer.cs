// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Text;
using FSStandardLibrary.Core.Checking.ArgumentChecking;
using FSStandardLibrary.Core.Codes;

#endregion

namespace FSWeatherInformation.Core.Normalizer
{
    /// <summary>
    ///     Static class that normalizes weather string representation.
    /// </summary>
    public static class Normalizer
    {
        /// <summary>
        ///     Generates a clean (without formatting and meta-information) string from <paramref name="stringToClean" />.
        /// </summary>
        /// <param name="stringToClean">String from which to get the clean string.</param>
        /// <param name="icaoCode">ICAO code required to properly generate a clean string.</param>
        /// <returns>Clean (without different formatting and meta-information) string.</returns>
        private static string GetCleanMetarOrTafRawString(string stringToClean, string icaoCode)
        {
            string[] splitString = stringToClean.Split('\n', '\t', '\r', ' ');
            bool cleanStringStarted = false;
            StringBuilder cleanStringBuilder = new StringBuilder("");
            foreach (var word in splitString)
            {
                if (cleanStringStarted)
                {
                    cleanStringBuilder.Append($" {word}");
                }
                else
                {
                    if (word == icaoCode)
                    {
                        cleanStringStarted = true;
                        cleanStringBuilder.Append(icaoCode);
                    }
                }
            }

            return cleanStringBuilder.ToString();
        }

        /// <summary>
        ///     Returns a normalized METAR weather information string of standard form from the input raw string.
        /// </summary>
        /// <param name="found">Was METAR information found.</param>
        /// <param name="rawMetarString">
        ///     Raw METAR string to form a normalized string.
        /// </param>
        /// <param name="icaoCode">Airport ICAO code for which this information was retrieved.</param>
        /// <returns>Normalized METAR string.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="icaoCode" /> is <c>null</c>.</exception>
        public static string GetNormalizedMetarStringFrom(bool found, string rawMetarString, IcaoCode icaoCode)
        {
            NullChecking.ThrowExceptionIfNull(icaoCode, nameof(icaoCode));

            if (found && StringArgumentChecking.IsStringValid(rawMetarString))
            {
                return $"METAR {GetCleanMetarOrTafRawString(rawMetarString, icaoCode.Code)}";
            }

            return rawMetarString;
        }

        /// <summary>
        ///     Returns a normalized TAF weather information string of standard form from the input raw string.
        /// </summary>
        /// <param name="found">Was TAF information found.</param>
        /// <param name="rawTafString">
        ///     Raw TAF string to form a normalized string.
        /// </param>
        /// <param name="icaoCode">Airport ICAO code for which this information was retrieved.</param>
        /// <returns>Normalized TAF string.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="icaoCode" /> is <c>null</c>.</exception>
        public static string GetNormalizedTafStringFrom(bool found, string rawTafString, IcaoCode icaoCode)
        {
            NullChecking.ThrowExceptionIfNull(icaoCode, nameof(icaoCode));

            if (found && StringArgumentChecking.IsStringValid(rawTafString))
            {
                return $"TAF {GetCleanMetarOrTafRawString(rawTafString, icaoCode.Code)}";
            }

            return rawTafString;
        }
    }
}