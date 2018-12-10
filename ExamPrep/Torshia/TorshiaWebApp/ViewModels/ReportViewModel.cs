using System;
using System.Collections.Generic;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.ViewModels
{
    public class ReportViewModel
    {
        public ReportViewModel()
        {
            this.AllReportViewModels = new List<ReportViewModel>();
        }
        public string Id { get; set; }
        public string TaskTitle { get; set; }
        public Task Task { get; set; }
        public int Level { get; set; }
        public string Status { get; set; }
        public ICollection<ReportViewModel> AllReportViewModels { get; set; }
        public DateTime ReportedOn { get; set; }
        public string ReporterName { get; set; }
    }
}
