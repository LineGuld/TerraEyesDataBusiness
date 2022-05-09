using System;

namespace TerraEyes_BusinessServer.Models
{
    public class Measurement
    {
        public string Eui { get; set; }
        public bool ServoTriggered { get; set; }
        public bool Light { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double CarbonDioxide { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}