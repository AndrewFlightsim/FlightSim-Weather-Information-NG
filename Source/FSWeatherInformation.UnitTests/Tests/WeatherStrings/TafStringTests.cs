// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FluentAssertions;
using FSStandardLibrary.Core.Codes;
using FSWeatherInformation.Core.Source;
using FSWeatherInformation.Core.WeatherStrings;
using NUnit.Framework;
using TestingHelper.Weather.UsefulData;

#endregion

namespace FSWeatherInformation.UnitTests.Tests.WeatherStrings
{
    [Category("Unit")]
    [TestFixture]
    public class TafStringTests
    {
        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void Constructor_WithCorrectData_ShouldConstruct(IcaoCode icao, string data, bool found,
            WeatherSource source)
        {
            //Arrange & act
            TafString tafString = new TafString(icao, data, found, source);

            //Assert
            tafString.AirportIcaoCode.Should().Be(icao);
            tafString.String.Should().Contain(icao.Code);
            tafString.Found.Should().Be(found);
            tafString.Source.Should().Be(source);
        }


        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.IncorrectDataForConstruction))]
        public void Constructor_WithIncorrectDataString_ShouldThrow_ArgumentException(IcaoCode icao,
            string data, bool found, WeatherSource source)
        {
            //Arrange
            Action act = () => new TafString(icao, data, found, source);

            //Act & assert
            act.Should().ThrowExactly<ArgumentException>();
        }

        [TestCaseSource(typeof(DataForWeatherStrings),
            nameof(DataForWeatherStrings.DataForConstructionWithNullIcaoCode))]
        public void Constructor_WithNullIcaoCode_ShouldThrow_ArgumentNullException(IcaoCode icao,
            string data, bool found, WeatherSource source)
        {
            //Arrange
            Action act = () => new TafString(icao, data, found, source);

            //Act & assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }


        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.DataWitnNotFoundWeatherString))]
        public void Constructor_WithSemiorrectData_ShouldConstructAndProcessInnerDataToBeSafe(IcaoCode icao,
            string data,
            bool found, WeatherSource source)
        {
            //Arrange & act
            TafString tafString = new TafString(icao, data, found, source);

            //Assert
            tafString.AirportIcaoCode.Should().Be(icao);
            tafString.String.Should().Contain(icao.Code).And.Contain("Not found");
            tafString.Found.Should().Be(found);
            tafString.Source.Should().Be(source);
        }

        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void Equals_WithEqualObjects_ShouldWorkAsExpected(IcaoCode icao, string data, bool found,
            WeatherSource source)
        {
            //Arrange & act
            TafString weatherString1 = new TafString(icao, data, found, source);
            TafString weatherString2 = new TafString(icao, data, found, source);

            //Assert
            weatherString1.Should().Be(weatherString2);
        }

        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void Equals_WithNotEqualObjects_ShouldWorkAsExpected(IcaoCode icao, string data, bool found,
            WeatherSource source)
        {
            //Arrange & act
            TafString weatherString1 = new TafString(icao, data, found, source);
            TafString weatherString2 = new TafString(icao, data ?? "Something not null", !found, source);
            TafString weatherString3 = null;

            //Assert
            weatherString1.Should().NotBe(weatherString2);
            weatherString1.Should().NotBe(weatherString3);
            weatherString2.Should().NotBe(weatherString3);
            weatherString1.Should().NotBe(new object());
            weatherString2.Should().NotBe(4);
        }

        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void GetHashCode_WithEqualObjects_ShouldWorkAsExpected(IcaoCode icao, string data, bool found,
            WeatherSource source)
        {
            //Arrange
            TafString weatherString1 = new TafString(icao, data, found, source);
            TafString weatherString2 = new TafString(icao, data, found, source);

            //Act & assert
            weatherString1.GetHashCode().Should().Be(weatherString2.GetHashCode());
        }

        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void GetHashCode_WithNotEqualObjects_ShouldWorkAsExpected(IcaoCode icao, string data, bool found,
            WeatherSource source)
        {
            //Arrange & act
            TafString weatherString1 = new TafString(icao, data, found, source);
            TafString weatherString2 = new TafString(icao, data ?? "Something not null", !found, source);

            //Act & assert
            weatherString1.Should().NotBe(weatherString2.GetHashCode());
        }

        [TestCaseSource(typeof(DataForWeatherStrings), nameof(DataForWeatherStrings.CorrectDataForConstruction))]
        public void TafString_ToString(IcaoCode icao, string data, bool found, WeatherSource source)
        {
            //Arrange
            TafString tafString = new TafString(icao, data, found, source);

            //Act & assert
            tafString.ToString().Should().Contain(tafString.AirportIcaoCode.Code);
        }
    }
}