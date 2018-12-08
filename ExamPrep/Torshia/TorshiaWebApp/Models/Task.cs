﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorshiaWebApp.Models
{
    public class Task
    {
        public Task()
        {
            this.Participants = new List<Participant>();
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

        public ICollection<Participant> Participants { get; set; }

        public ICollection<Sector> AffectedSectors { get; set; }
    }
}