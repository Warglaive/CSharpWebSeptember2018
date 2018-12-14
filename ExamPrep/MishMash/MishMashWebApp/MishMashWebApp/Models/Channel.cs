using System.Collections.Generic;
using MishMashWebApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new List<UsersChannels>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Type Type { get; set; }
        public string Tags { get; set; }
        public ICollection<UsersChannels> Followers { get; set; }
    }
}