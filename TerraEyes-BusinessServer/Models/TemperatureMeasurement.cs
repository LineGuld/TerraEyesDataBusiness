namespace TerraEyes_BusinessServer.Models
{
    public class TemperatureMeasurement
    {
        public TemperatureMeasurement()
        {
        }

        public TemperatureMeasurement(int id, int temperature)
        {
            Id = id;
            TemperatureReading = temperature;
        }

        public int Id { get; set; }
        public int TemperatureReading { get; set; }
    }
}