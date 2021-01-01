// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FluentAssertions;
using FSWeatherInformation.Core.Statistics;
using FSWeatherInformation.Core.WeatherStrings;
using NUnit.Framework;

#endregion

namespace FSWeatherInformation.UnitTests.Tests.Statistics
{
    [Category("Unit")]
    [TestFixture]
    public class InformationStatisticsTests
    {
        [Test]
        public void Constructor_ShouldProcessInformationTypeCorrectly()
        {
            //Arrange & act
            InformationStatistics<MetarString> testStatistics = new InformationStatistics<MetarString>();

            //Assert
            testStatistics.StatisticsForType.Should().Be(typeof(MetarString));
        }

        [Test]
        public void SetValueOfNumberOfRequests()
        {
            //Arrange & act
            InformationStatistics<object> testStatistics = new InformationStatistics<object>();
            int initialValue = testStatistics.NumberOfRequestsToDownloadInformation;
            int expectedValue = 9;
            testStatistics.NumberOfRequestsToDownloadInformation = expectedValue;

            //Assert
            initialValue.Should().Be(0);
            testStatistics.NumberOfRequestsToDownloadInformation.Should().Be(expectedValue);
        }
    }
}