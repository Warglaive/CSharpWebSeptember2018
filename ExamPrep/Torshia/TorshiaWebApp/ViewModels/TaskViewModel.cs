using System;
using System.Collections.Generic;

namespace TorshiaWebApp.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            this.Participants = new List<string>();
            this.AffectedSectors = new List<string>();
        }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public bool IsReported { get; set; } = false;

        public ICollection<string> Participants { get; set; }

        public ICollection<string> AffectedSectors { get; set; }
    }
}
