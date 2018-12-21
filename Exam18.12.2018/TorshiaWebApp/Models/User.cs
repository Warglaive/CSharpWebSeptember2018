using System.ComponentModel.DataAnnotations;
using TorshiaWebApp.Models.Enums;

namespace TorshiaWebApp.Models
{
    public class User
    {
        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}