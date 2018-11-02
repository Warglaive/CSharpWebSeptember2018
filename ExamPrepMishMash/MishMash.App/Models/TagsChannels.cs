namespace MishMash.App.Models
{
    public class TagsChannels
    {
        public int Id { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }

        public virtual Channel Channel { get; set; }
        public int ChannelId { get; set; }
    }
}