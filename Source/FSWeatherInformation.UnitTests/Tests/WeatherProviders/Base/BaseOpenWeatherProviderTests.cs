// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FSStandardLibrary.Core.Downloader.General;
using FSWeatherInformation.Core.Source;
using FSWeatherInformation.Core.WeatherProviders.Base;
using NUnit.Framework;
using TestingHelper.Downloader;
using TestingHelper.Weather.WeatherSourceData;

#endregion

namespace FSWeatherInformation.UnitTests.Tests.WeatherProviders.Base
{
    [Category("Unit")]
    [TestFixture]
    public class BaseOpenWeatherProviderTests
    {
        [TestCaseSource(typeof(WeatherSourceAsData), nameof(WeatherSourceAsData.CorrectWeatherSourceObjects))]
        public void Constructor_WithCorrectData_ShouldConstruct(WeatherSource source)
        {
            //Arrange & act
            DownloaderStub<string, Uri> downloader = new DownloaderStub<string, Uri>();
            BaseOpenWeatherProvider baseOpenWeatherProvider =
                new BaseOpenWeatherProvider(source, downloader);

            //Assert
            baseOpenWeatherProvider.Source.Should().Be(source);
            baseOpenWeatherProvider.Downloader.Should().Be(downloader);
        }

        [TestCaseSource(typeof(BaseOpenWeatherProviderTests), nameof(IncorrectDataForConstruction))]
        public void Constructor_WithIncorrectData_ShouldThrow_ArgumentNullException(WeatherSource source,
            IDownloader<string, Uri> downloader)
        {
            //Arrange
            Action act = () => new BaseOpenWeatherProvider(source, downloader);

            //Act & assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        public static IEnumerable<object[]> IncorrectDataForConstruction
        {
            get
            {
                return new[]
                {
                    new object[] {null, null},
                    new[] {WeatherSourceAsData.CorrectWeatherSourceObjects.First().First(), null},
                    new object[] {null, new DownloaderStub<string, Uri>()},
                };
            }
        }
    }
}