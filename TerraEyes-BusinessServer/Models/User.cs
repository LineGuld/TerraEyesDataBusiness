using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerraEyes_BusinessServer.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        public User()
        {
        }

        public List<Terrarium> Terraria { get; set; }

        public User(string id)
        {
            Id = id;
            Terraria = new List<Terrarium>();
        } 
    }
}