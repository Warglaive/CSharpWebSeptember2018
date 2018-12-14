﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MishMashWebApp.Models.Enums;

namespace MishMashWebApp.Models
{
    public class User
    {
        public User()
        {
            this.FollowedChannels = new HashSet<UsersChannels>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public ICollection<UsersChannels> FollowedChannels { get; set; }
        public Role Role { get; set; }
    }
}