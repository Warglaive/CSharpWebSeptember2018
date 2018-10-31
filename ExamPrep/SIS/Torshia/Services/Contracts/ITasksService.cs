using System.Linq;
using Torshia.Models;

namespace Torshia.Web.Services.Contracts
{
    public interface ITasksService
    {
        IQueryable<Task> All();
    }
}