using System;

namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public abstract class Measurement
    {
        public int Id { get; set; }
        public string Eui { get; set; }

        public string Timestamp { get; set; }

        protected Measurement() 
        {
        }

        protected Measurement(String timestamp, string eui)
        { 
            Timestamp = timestamp;
            Eui = eui;
        }
    }
}