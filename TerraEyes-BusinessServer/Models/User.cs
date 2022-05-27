using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerraEyes_BusinessServer.Models
{
    public class User
    {
        [Required]
        public string UserId { get; set; }

        public List<Terrarium> Terraria { get; set; }

        public User(string userId)
        {
            UserId = userId;
            Terraria = new List<Terrarium>();
        }
    }
}