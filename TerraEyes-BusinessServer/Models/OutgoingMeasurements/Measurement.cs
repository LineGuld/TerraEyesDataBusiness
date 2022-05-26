using System;

namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public abstract class Measurement
    {
        public int Id { get; set; }
        public string EUI { get; set; }

        public DateTime Timestamp { get; set; }

        protected Measurement() 
        {
        }

        protected Measurement(DateTime timestamp, string eui)
        { 
            Timestamp = timestamp;
            EUI = eui;
        }
    }
}