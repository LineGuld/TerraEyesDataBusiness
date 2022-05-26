using System;
using System.Collections.Generic;
using TerraEyes_BusinessServer.Hubs;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Models.OutgoingMeasurements;
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
        public void GetActivityForUserTest()
        {
            List<ActivityMeasurement> results = appHub.ActivityDataFromDataToAndroid("jack").Result;

            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(2, results[0].Measurement);
        }
        
        [Fact]
        public void GetActivityForTerrariumTest()
        {
            List<ActivityMeasurement> results = appHub.TerrariumActivityDataFromDataToAndroid("abc123").Result;

            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(2, results[0].Measurement);
        }

        [Fact]
        public void GetCarbonForUserTest()
        {
            List<CarbondioxideMeasurement> results = appHub.CarbonDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(350, results[0].Measurement);
        }
        
        [Fact]
        public void GetCarbonForTerrariumTest()
        {
            List<CarbondioxideMeasurement> results = appHub.TerrariumCarbonDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(350, results[0].Measurement);
        }
        
        [Fact]
        public void GetHumidityForUserTest()
        {
            List<HumidityMeasurement> results = appHub.HumidityDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(72.2, results[0].Measurement);
        }
        
        [Fact]
        public void GetHumidityForTerrariumTest()
        {
            List<HumidityMeasurement> results = appHub.TerrariumHumidityDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(72.2, results[0].Measurement);
        }
        
        
        
        [Fact]
        public void FetchTemperatureReadingsTest()
        {
            List<TemperatureMeasurement> results = appHub.TemperatureDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", results[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", results[0].Timestamp);
            Assert.Equal(26.2, results[0].Measurement);
        }

        [Fact]
        public void FetchTemperatureFromTerrarium()
        {
            List<TemperatureMeasurement> results = appHub.TerrariumTemperatureDataFromDataToAndroid("jack", "123abc").Result;
            Assert.Equal(33.2, results[0].Measurement);
        }

        [Fact]
        public void filterTemperaturesByTerrarium()
        {
            List<TemperatureMeasurement> abc123 = appHub.TerrariumTemperatureDataFromDataToAndroid("jack", "abc123").Result;
            List<TemperatureMeasurement> to = appHub.TerrariumTemperatureDataFromDataToAndroid("jack", "123abc").Result;

            Assert.NotEqual(abc123[0].Measurement, to[0].Measurement);
        }
        
        
        

        


    }
}