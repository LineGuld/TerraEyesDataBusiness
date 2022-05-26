namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public class TemperatureMeasurement : Measurement
    {
        public TemperatureMeasurement()
        {
        }

        public TemperatureMeasurement(int temperature)
        {
            Measurement = temperature;
        }

       // public int Id { get; set; }
        public double Measurement { get; set; }
    }
}