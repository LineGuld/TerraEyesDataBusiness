using System;

namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public class ActivityMeasurement : Measurement
    {
        public int Measurement { get; set; }

        public ActivityMeasurement() : base()
        {
        }

        public ActivityMeasurement(DateTime timestamp, string eui, int measurement) : base(timestamp, eui)
        {
            Measurement = measurement;
        }
    }
}