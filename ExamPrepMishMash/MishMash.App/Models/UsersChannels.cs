namespace MishMash.App.Models
{
    public class UsersChannels
    {
        public int Id { get; set; }
        public Channel Channel { get; set; }
        public int ChannelId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}