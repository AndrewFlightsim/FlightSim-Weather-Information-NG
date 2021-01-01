// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Threading.Tasks;
using FSStandardLibrary.Core.Codes;
using FSWeatherInformation.Core.Statistics;
using JetBrains.Annotations;

#endregion

namespace FSWeatherInformation.Core.ServiceTypes
{
    public interface IInformationProviderOfType<T>
    {
        /// <summary>
        ///     Asynchronously downloads information of type <typeparamref name="T" /> for specified ICAO code.
        /// </summary>
        /// <param name="icaoCodeContainer">
        ///     Class that contain ICAO code of airport to download information.
        /// </param>
        /// <returns>Task to download information of type <typeparamref name="T" />.</returns>
        [NotNull]
        Task<T> DownloadInformationAsync([NotNull] IIcaoCodeContainer icaoCodeContainer);

        /// <summary>
        ///     Asynchronously downloads information of type <typeparamref name="T" /> for specified ICAO codes.
        /// </summary>
        /// <param name="icaoCodeContainers">
        ///     Collection of classes that contain ICAO codes of airports to download information.
        /// </param>
        /// <returns>
        ///     Task to download the list of < see cref="List {T} " /> information elements of type <typeparamref name="T" />
        ///     according to
        ///     specified ICAO codes of airports, where <c> T </c> - <typeparamref name="T" />.
        /// </returns>
        [NotNull]
        Task<List<T>> DownloadSeveralPiecesOfInformationAsync(
            [NotNull] IReadOnlyList<IIcaoCodeContainer> icaoCodeContainers);

        /// <summary>
        ///     Statistic for current information provider.
        /// </summary>
        /// <returns>Statistic for current information provider.</returns>
        InformationStatistics<T> GetInformationProviderStatistics();
    }
}