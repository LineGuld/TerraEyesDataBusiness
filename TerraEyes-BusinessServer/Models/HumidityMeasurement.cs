namespace TerraEyes_BusinessServer.Models
{
    public class HumidityMeasurement
    {
        public int Id { get; set; }
        public double HumidityReading { get; set; }

        public HumidityMeasurement(int id, double humidityReading)
        {
            Id = id;
            HumidityReading = humidityReading;
        }

        public HumidityMeasurement()
        {
        }
    }
}