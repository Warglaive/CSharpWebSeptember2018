using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
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
                    TaskTitle = report.Task.Title,
                    Level = report.Task.AffectedSectors.Count,
                    Status = report.Status.ToString(),
                    Task = report.Task

                });
            }

            //for (int i = 0; i < viewModel.AllReportViewModels.Count; i++)
            //{
            //    viewModel.AllReportViewModels.ToList()[i].Level
            //}
            return this.View(viewModel);
        }
    }
}