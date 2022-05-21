namespace TerraEyes_BusinessServer.Models
{
    public class CarbondioxideMeasurement
    {
        public int Id { get; set; }
        public int CarbonReading { get; set; }

        public CarbondioxideMeasurement(int id, int carbonReading)
        {
            Id = id;
            CarbonReading = carbonReading;
        }

        public CarbondioxideMeasurement()
        {
        }
    }
}