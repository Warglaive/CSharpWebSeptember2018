using System.Collections.Generic;
using MishMashWebApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new List<User>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Type Type { get; set; }
        public string Tags { get; set; }
        public ICollection<User> Followers { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}