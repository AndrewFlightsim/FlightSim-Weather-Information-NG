// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;

#endregion

namespace FSWeatherInformation.Core.Statistics
{
    /// <summary>
    ///     Interface of a class (weather information source mainly) that supports calculation of number of requests for
    ///     getting specific kind of information (of type <typeparamref name="T" />).
    /// </summary>
    public class InformationStatistics<T>
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public InformationStatistics()
        {
            StatisticsForType = typeof(T);
        }

        /// <summary>
        ///     number of requests for getting specific kind of information (of type <typeparamref name="T" />).
        /// </summary>
        public int NumberOfRequestsToDownloadInformation { get; set; }

        /// <summary>
        ///     Type of information for which this statistic is calculated.
        /// </summary>
        public Type StatisticsForType { get; }
    }
}