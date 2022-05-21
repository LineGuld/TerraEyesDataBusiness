using System;

namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public abstract class Measurement
    {
        public DateTime Timestamp { get; set; }
        public string EUI { get; set; }

        protected Measurement(DateTime timestamp, string eui)
        {
            Timestamp = timestamp;
            EUI = eui;
        }
    }
}