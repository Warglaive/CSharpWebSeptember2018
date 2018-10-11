using System;

namespace RunesApp.Models
{
    public class User
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}