using System;
using System.Runtime.Serialization;

namespace TerraEyes_BusinessServer.Models
{
    public class Measurement
    {
        public string Eui { get; set; }
        public bool ServoTriggered { get; set; }
        public int Pir { get; set; }
        public double Light { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int CarbonDioxide { get; set; }
        public string TimeStamp { get; set; }

        public override string ToString()
        {
            return $"EUI: {Eui}\n" +
                   $"ts: {TimeStamp}\n" +
                   $"Temp: {Temperature} C\u00b0 \n" +
                   $"Humid: {Humidity}%\n" +
                   $"Co2: {CarbonDioxide} ppm\n" +
                   $"Pir: {Pir}\n" +
                   $"Lumen: {Light}\n" +
                   $"Servo: {ServoTriggered}";
        }
    }
    
}