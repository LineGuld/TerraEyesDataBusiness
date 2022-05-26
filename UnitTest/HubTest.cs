using System;
using System.Collections.Generic;
using TerraEyes_BusinessServer.Hubs;
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
            List<ActivityMeasurement> result = appHub.ActivityDataFromDataToAndroid("jack").Result;

            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(2, result[0].Measurement);
        }
        
        [Fact]
        public void GetActivityForTerrariumTest()
        {
            List<ActivityMeasurement> result = appHub.TerrariumActivityDataFromDataToAndroid("abc123").Result;

            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(2, result[0].Measurement);
        }

        [Fact]
        public void GetCarbonForUserTest()
        {
            List<CarbondioxideMeasurement> result = appHub.CarbonDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(350, result[0].Measurement);
        }
        
        [Fact]
        public void GetCarbonForTerrariumTest()
        {
            List<CarbondioxideMeasurement> result = appHub.TerrariumCarbonDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(350, result[0].Measurement);
        }
        
        [Fact]
        public void GetHumidityForUserTest()
        {
            List<HumidityMeasurement> result = appHub.HumidityDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(72.2, result[0].Measurement);
        }
        
        [Fact]
        public void GetHumidityForTerrariumTest()
        {
            List<HumidityMeasurement> result = appHub.TerrariumHumidityDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(72.2, result[0].Measurement);
        }

        [Fact]
        public void GetLumenForUserTest()
        {
            List<LumenMeasurement> result = appHub.LumenDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(1234, result[0].Measurement);
        }

        [Fact]
        public void GetLumenForTerrariumTest()
        {
            List<LumenMeasurement> result = appHub.TerrariumLumenDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(1234, result[0].Measurement);
        }
        
        [Fact]
        public void GetServoForUserTest()
        {
            List<ServoMeasurement> result = appHub.ServoDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.False(result[0].Measurement);
        }
        
        [Fact]
        public void GetServoForTerrariumTest()
        {
            List<ServoMeasurement> result = appHub.TerrariumServoDataFromDataToAndroid("abc123").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.False(result[0].Measurement);
        }
        
        [Fact]
        public void FetchTemperatureReadingsTest()
        {
            List<TemperatureMeasurement> result = appHub.TemperatureDataFromDataToAndroid("jack").Result;
            
            Assert.Equal("abc123", result[0].Eui);
            Assert.Equal("2022-05-24T09:05:00.000+00:00", result[0].Timestamp);
            Assert.Equal(26.2, result[0].Measurement);
        }

        [Fact]
        public void FetchTemperatureFromTerrarium()
        {
            List<TemperatureMeasurement> result = appHub.TerrariumTemperatureDataFromDataToAndroid("123abc").Result;
            Assert.Equal("123abc", result[0].Eui);
            Assert.Equal("2022-05-24T09:15:00.000+00:00", result[0].Timestamp);
            Assert.Equal(33.2, result[0].Measurement);
        }

        
        [Fact]
        public void filterTemperaturesByTerrarium()
        {
            List<TemperatureMeasurement> abc123 = appHub.TerrariumTemperatureDataFromDataToAndroid("abc123").Result;
            List<TemperatureMeasurement> to = appHub.TerrariumTemperatureDataFromDataToAndroid("123abc").Result;

            Assert.NotEqual(abc123[0].Measurement, to[0].Measurement);
        }
        
        
        

        


    }
}