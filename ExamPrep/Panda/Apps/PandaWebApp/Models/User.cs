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

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}