using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers.Reports
{
    public class ReportsController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var viewModel = new ReportViewModel();

            var allReports = this.TorshiaDbContext.Reports.Include(x => x.Task).ThenInclude(x => x.AffectedSectors);
            foreach (var report in allReports)
            {
                viewModel.AllReportViewModels.Add(new ReportViewModel
                {
                    Id = report.Id,
                    TaskTitle = report.Task.Title,
                    Level = report.Task.AffectedSectors.Count,
                    Status = report.Status.ToString(),
                    Task = report.Task

                });
            }
            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Details(string id)
        {
            var report = this.TorshiaDbContext.Reports.Include(x => x.Task)
                .ThenInclude(x => x.AffectedSectors).FirstOrDefault(x => x.Id == id);
            var reporter = this.TorshiaDbContext.Users.FirstOrDefault(x => x.Id == report.ReporterId);

            var viewModel = new ReportViewModel
            {
                Id = report.Id,
                Level = report.Task.AffectedSectors.Count,
                Status = report.Status.ToString(),
                Task = report.Task,
                ReportedOn = report.ReportedOn,
                ReporterName = reporter.Username
            };
            return this.View(viewModel);
        }
    }
}