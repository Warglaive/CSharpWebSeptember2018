using System.Linq;
using Torshia.Data;
using Torshia.Models;
using Torshia.Web.Services.Contracts;

namespace Torshia.Web.Services
{
    public class ReportsService : IReportsService
    {
        private readonly TorshiaContext context;

        public ReportsService(TorshiaContext context)
        {
            this.context = context;
        }

        public IQueryable<Report> All()
        {
            return this.context.Reports;
        }
    }
}