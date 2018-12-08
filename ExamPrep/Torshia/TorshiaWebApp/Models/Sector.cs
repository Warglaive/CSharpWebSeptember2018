using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TorshiaWebApp.Models
{
    public class Sector
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}