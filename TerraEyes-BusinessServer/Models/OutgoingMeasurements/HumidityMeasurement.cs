namespace TerraEyes_BusinessServer.Models
{
    public class HumidityMeasurement : Measurement
    {
        public int Id { get; set; }
        public double HumidityReading { get; set; }

        public HumidityMeasurement(double humidityReading)
        {
            HumidityReading = humidityReading;
        }

        public HumidityMeasurement()
        {
        }
    }
}