using System.Collections.Generic;
using MishMashWebApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new List<UserChannel>();
            this.Tags = new List<Tag>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Type Type { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string TagId { get; set; }
        public ICollection<UserChannel> Followers { get; set; }
    }
}