using PandaWebApp.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PandaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Packages = new List<Package>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}