using System;
using System.Collections.Generic;

namespace Torshia.Models
{
    public class Task
    {
        public Task()
        {
            this.AffectedSectors = new HashSet<AffectedSectors>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; } = false;

        public string Description { get; set; }

        public string Participants { get; set; }

        public IEnumerable<AffectedSectors> AffectedSectors { get; set; }
    }
}