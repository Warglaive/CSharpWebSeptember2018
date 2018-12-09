using System;
using System.Collections.Generic;

namespace TorshiaWebApp.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            this.AllTasks = new List<TaskViewModel>();
        }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public bool IsReported { get; set; } = false;

        public string Participants { get; set; }

        public string SectorCustomers { get; set; }
        public string SectorMarketing { get; set; }
        public string SectorFinances { get; set; }
        public string SectorInternal { get; set; }
        public string SectorManagement { get; set; }

        public int Level { get; set; }

        public ICollection<TaskViewModel> AllTasks { get; set; }
    }
}
