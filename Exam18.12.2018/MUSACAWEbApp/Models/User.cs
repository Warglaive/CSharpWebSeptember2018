﻿using System.ComponentModel.DataAnnotations;
using MUSACAWEbApp.Models.Enums;

namespace MUSACAWEbApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}