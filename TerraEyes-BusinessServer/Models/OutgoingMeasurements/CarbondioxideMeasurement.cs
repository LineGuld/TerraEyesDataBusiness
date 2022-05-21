using System.Transactions;

namespace TerraEyes_BusinessServer.Models
{
    public class CarbondioxideMeasurement : Measurement
    {
        
        public int CarbonReading { get; set; }

        public CarbondioxideMeasurement(int carbonReading)
        {
            CarbonReading = carbonReading;
        }

        public CarbondioxideMeasurement()
        {
        }
    }
}