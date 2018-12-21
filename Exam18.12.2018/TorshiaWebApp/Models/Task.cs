using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorshiaWebApp.Models
{
    public class Task
    {
        public Task()
        {
            this.AffectedSectors = new List<Sector>();
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; } = false;

        public string Description { get; set; }

        [Required]
        public string Participants { get; set; }
        public ICollection<Sector> AffectedSectors { get; set; }

        [NotMapped]
        public int Level { get; set; }
    }
}