using System.Transactions;

namespace TerraEyes_BusinessServer.Models
{
    public class CarbondioxideMeasurement : Measurement
    {
        
        public int Measurement { get; set; }

        public CarbondioxideMeasurement(int carbonReading)
        {
            Measurement = carbonReading;
        }

        public CarbondioxideMeasurement()
        {
        }
    }
}