using System.Collections.Generic;

namespace MishMash.App.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Channels = new HashSet<TagsChannels>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TagsChannels> Channels { get; set; }
    }
}