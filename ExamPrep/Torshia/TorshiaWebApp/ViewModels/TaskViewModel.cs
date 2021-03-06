﻿using System;
using System.Collections.Generic;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            this.AllTasks = new List<TaskViewModel>();
        }

        public string Id { get; set; }

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
        public string AffectedSectors { get; set; }
        public string Status { get; set; }
    }
}
