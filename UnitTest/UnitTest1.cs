using System;
using System.Collections.Generic;
using TerraEyes_BusinessServer.Hubs;
using TerraEyes_BusinessServer.Models;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void FetchTemperatureReadingsTest()
        { 
            AppHub test = new AppHub();
           List<TemperatureMeasurement> results = test.TemperatureDataFromDataToAndroid("jack").Result;
           
           Assert.Equal(12.3, results[0].Measurement);
        }
        
        
    }
}