using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.Models
{
    public class Tag
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string ChannelId { get; set; }
    }
}