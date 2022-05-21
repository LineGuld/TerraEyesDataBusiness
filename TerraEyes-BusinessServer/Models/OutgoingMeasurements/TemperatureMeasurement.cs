namespace TerraEyes_BusinessServer.Models
{
    public class TemperatureMeasurement : Measurement
    {
        public TemperatureMeasurement()
        {
        }

        public TemperatureMeasurement(int temperature)
        {
            TemperatureReading = temperature;
        }

        public int Id { get; set; }
        public int TemperatureReading { get; set; }
    }
}