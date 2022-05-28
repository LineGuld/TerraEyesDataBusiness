namespace TerraEyes_BusinessServer.Models
{
    public class Terrarium
    {
        public string Eui { get; set; }
        public string UserId { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinHumidity { get; set; }
        public double MaxHumidity { get; set; }
        public int MaxCarbonDioxide { get; set; }

        public Terrarium()
        {
        }
    }
}