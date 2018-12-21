using System;
using System.ComponentModel.DataAnnotations;
using TorshiaWebApp.Models.Enums;

namespace TorshiaWebApp.Models
{
    public class Report
    {
        [Required]
        [Key]
        public string Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public Task Task { get; set; }
        public string TaskId { get; set; }

        public User Reporter { get; set; }
        public string ReporterId { get; set; }
    }
}