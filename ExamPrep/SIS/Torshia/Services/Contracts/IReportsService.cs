using System.Linq;
using Torshia.Models;

namespace Torshia.Web.Services.Contracts
{
    public interface IReportsService
    {
        IQueryable<Report> All();
    }
}