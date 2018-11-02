using System.Collections.Generic;
using MishMash.App.Models.Enums;

namespace MishMash.App.Models
{
    public class User
    {
        public User()
        {
            this.Channels = new HashSet<UsersChannels>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UsersChannels> Channels { get; set; }
        public Role Role { get; set; }
    }
}