using System;
using System.Runtime.Serialization;

namespace TerraEyes_BusinessServer.Models
{
    public class Measurement
    {
        public string Eui { get; set; }
        public bool ServoMoved { get; set; }
        public int Activity { get; set; }
        public double Lumen { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int CarbonDioxide { get; set; }
        public string Timestamp { get; set; }

        public override string ToString()
        {
            return $"EUI: {Eui}\n" +
                   $"ts: {Timestamp}\n" +
                   $"Temp: {Temperature} C\u00b0 \n" +
                   $"Humid: {Humidity}%\n" +
                   $"Co2: {CarbonDioxide} ppm\n" +
                   $"Pir: {Activity}\n" +
                   $"Lumen: {Lumen}\n" +
                   $"Servo: {ServoMoved}";
        }
    }
    
}