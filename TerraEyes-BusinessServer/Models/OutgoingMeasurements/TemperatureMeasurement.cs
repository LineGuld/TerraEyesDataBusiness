namespace TerraEyes_BusinessServer.Models.OutgoingMeasurements
{
    public class TemperatureMeasurement : Measurement
    {
       public double Measurement { get; set; }
       
       public TemperatureMeasurement() : base()
       {
       }
    }
}