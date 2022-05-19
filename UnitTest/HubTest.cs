using System;
using System.Collections.Generic;
using TerraEyes_BusinessServer.Hubs;
using TerraEyes_BusinessServer.Models;
using Xunit;

namespace UnitTest
{
    public class HubTest
    {
        private readonly AppHub appHub;

        public HubTest()
        {
            appHub = new AppHub();
        }

        [Fact]
        public void FetchTemperatureReadingsTest()
        { 
           List<TemperatureMeasurement> results = appHub.TemperatureDataFromDataToAndroid("1").Result;
           Assert.Equal(42, results[0].TemperatureReading);
        }

        [Fact]
        public void FetchHumidityReadingTest()
        {
            List<HumidityMeasurement> results = appHub.HumidityDataFromDataToAndroid("1").Result;
            Assert.StrictEqual(42, results[0].HumidityReading);
        }

        [Fact]
        public void FetchCarbonReadingTest()
        {
            List<CarbonMeasurement> results = appHub.CarbondioxideDataFromDataToAndroid("1").Result;
            Assert.StrictEqual(42, results[0].CarbonReading);
        }
    }
}