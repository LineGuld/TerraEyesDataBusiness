using System;

namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public class HumidityMeasurement : Measurement
    {
        public double Measurement { get; set; }

        public HumidityMeasurement() : base()
        {
        }
    }
}