using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.ViewModels
{
    public class ChannelViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
    }
}
