using System.Collections.Generic;
using SIS.Framework.ActionResults;
using Torshia.Web.Controllers.Base;
using Torshia.Web.Services.Contracts;
using Torshia.Web.ViewModels;

namespace Torshia.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IReportsService reportsService;

        public HomeController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        public IActionResult Index()
        {
            var userLoggedIn = this.Identity != null;
            if (!userLoggedIn)
            {
                return this.View();
            }
            
            var reports = reportsService.All();
            var reportViewModels = new List<ReportViewModel>();
            foreach (var report in reports)
            {
                reportViewModels.Add(new ReportViewModel
                {
                    //Title = report.Task.Title,
                    //Level = report.Task.AffectedSectors.Count
                });
            }
            //this.Model.Data["ReportViewModels"] = reportViewModels;
            return this.View();
        }
    }
}