using System.ComponentModel.DataAnnotations;

namespace TorshiaWebApp.Models
{
    public class Sector
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string TaskId { get; set; }
    }
}