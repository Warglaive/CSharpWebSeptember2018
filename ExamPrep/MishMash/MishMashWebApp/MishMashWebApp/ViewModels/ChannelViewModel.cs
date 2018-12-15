using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MishMashWebApp.Models;

namespace MishMashWebApp.ViewModels
{
    public class ChannelViewModel
    {
        public ChannelViewModel()
        {
            this.SeeOther = new List<Channel>();
            this.SuggestedChannels = new HashSet<Channel>();
            this.YourChannels = new List<UserChannel>();
        }
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public int Followers { get; set; }
        public ICollection<UserChannel> YourChannels { get; set; }
        public ICollection<Channel> SuggestedChannels { get; set; }
        public ICollection<Channel> SeeOther { get; set; }
    }
}
