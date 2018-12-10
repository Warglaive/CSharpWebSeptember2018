using System.Linq;
using SIS.HTTP.Responses;

namespace TorshiaWebApp.Controllers.Reports
{
    public class ReportsController : BaseController
    {
        public IHttpResponse Report(string id)
        {
            var task = TorshiaDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            task.IsReported = true;
            //TODO:SET Isreported=true IN DB, CREATE REPORT On Report click
            //TODO CREATE All reports page, and details about report
            return this.View();
        }

        public IHttpResponse All()
        {
            return this.View();
        }
    }
}