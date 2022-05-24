namespace TerraEyes_BusinessServer.Models
{
    public class HumidityMeasurement : Measurement
    {
        public int Id { get; set; }
        public double Measurement { get; set; }

        public HumidityMeasurement(double humidityReading)
        {
            Measurement = humidityReading;
        }

        public HumidityMeasurement()
        {
        }
    }
}