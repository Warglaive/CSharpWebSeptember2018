namespace MishMashWebApp.Models
{
    public class UsersChannels
    {
        public User User { get; set; }
        public string UserId { get; set; }

        public Channel Channel { get; set; }
        public string ChannelId { get; set; }
    }
}