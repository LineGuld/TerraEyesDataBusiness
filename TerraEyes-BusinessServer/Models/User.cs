using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerraEyes_BusinessServer.Models
{
    public class User
    {
        public User(string userId)
        {
            UserId = userId;
        }

        [Required]
        public string UserId { get; set; }

        private List<Sensor> OwnedTerraria { get; set; }
    }
}