using System.ComponentModel.DataAnnotations;

namespace TerraEyes_BusinessServer.Models
{
    public class Sensor
    {
        [Required]
        public string SensorId { get; set; }
        [Required]
        public string UserId { get; set; } // vi har besluttet at den er i databasen og kan modtages fra appen også

        public UserSettings settings { get; set; }
    }
}