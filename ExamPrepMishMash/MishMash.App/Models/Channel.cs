using System.Collections.Generic;
using Type = MishMash.App.Models.Enums.Type;

namespace MishMash.App.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Tags = new HashSet<TagsChannels>();
            this.Followers = new HashSet<UsersChannels>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<TagsChannels> Tags { get; set; }
        public virtual ICollection<UsersChannels> Followers { get; set; }
    }
}