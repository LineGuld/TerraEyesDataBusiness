﻿using System.ComponentModel.DataAnnotations;

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

        public string ConnectionId { get; set; }
    }
}