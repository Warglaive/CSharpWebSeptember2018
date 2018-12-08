using System.ComponentModel.DataAnnotations;

namespace TorshiaWebApp.Models
{
    public class Participant
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
