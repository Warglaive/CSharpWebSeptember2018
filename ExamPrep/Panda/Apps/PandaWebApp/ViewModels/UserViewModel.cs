using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PandaWebApp.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.UsersAllNames = new HashSet<string>();
        }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public HashSet<string> UsersAllNames { get; set; }
    }
}