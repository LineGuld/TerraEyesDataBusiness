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
            Assert.Equal(12.3, results[0].Measurement);
        }

        [Fact]
        public void FetchTemperatureFromTerrarium()
        {
            List<TemperatureMeasurement> results = appHub.TemperatureDataFromDataToAndroid("jack", "ab23432").Result;
            Assert.Equal(16.3, results[2].Measurement);
        }

        [Fact]
        public void filterTemperaturesByTerrarium()
        {
            List<TemperatureMeasurement> ab23432 = appHub.TemperatureDataFromDataToAndroid("jack", "ab23432").Result;
            List<TemperatureMeasurement> bc6789 = appHub.TemperatureDataFromDataToAndroid("jack", "bc6789").Result;

            Assert.NotEqual(ab23432[0].Measurement, bc6789[0].Measurement);
        }
        
        
        [Fact]
        public void FetchHumidityReadingTest()
        {
            List<HumidityMeasurement> results = appHub.HumidityDataFromDataToAndroid("jack").Result;
            Assert.Equal(65.3, results[0].Measurement);
        }

        [Fact]
        public void FetchCarbonReadingTest()
        {
            List<CarbondioxideMeasurement> results = appHub.CarbonDataFromDataToAndroid("jack").Result;
            Assert.Equal(351, results[2].Measurement);
        }


    }
}