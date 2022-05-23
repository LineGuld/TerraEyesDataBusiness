using System;
using System.Collections.Generic;
using TerraEyes_BusinessServer.Hubs;
using TerraEyes_BusinessServer.Models;
using Xunit;

namespace UnitTest
{
    public class HubTest
    {
        //Component tests for making sure the functions interact correctly and returns the correct result to the hub
        private readonly AppHub appHub;

        public HubTest()
        {
            appHub = new AppHub();
        }

        [Fact]
        public void FetchTemperatureReadingsTest()
        {
            List<TemperatureMeasurement> results = appHub.TemperatureDataFromDataToAndroid("jack").Result;
            Assert.Equal(26.2, results[0].Measurement);
        }

        [Fact]
        public void FetchTemperatureFromTerrarium()
        {
            List<TemperatureMeasurement> results = appHub.TemperatureDataFromDataToAndroid("jack", "123abc").Result;
            Assert.Equal(33.2, results[0].Measurement);
        }

        [Fact]
        public void filterTemperaturesByTerrarium()
        {
            List<TemperatureMeasurement> abc123 = appHub.TemperatureDataFromDataToAndroid("jack", "abc123").Result;
            List<TemperatureMeasurement> to = appHub.TemperatureDataFromDataToAndroid("jack", "123abc").Result;

            Assert.NotEqual(abc123[0].Measurement, to[0].Measurement);
        }
        
        
        [Fact]
        public void FetchHumidityReadingTest()
        {
            List<HumidityMeasurement> results = appHub.HumidityDataFromDataToAndroid("jack").Result;
            Assert.Equal(72.2, results[0].Measurement);
        }

        [Fact]
        public void FetchCarbonReadingTest()
        {
            List<CarbondioxideMeasurement> results = appHub.CarbonDataFromDataToAndroid("jack").Result;
            Assert.Equal(350, results[0].Measurement);
        }


    }
}