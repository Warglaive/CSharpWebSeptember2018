using System.Linq;
using Torshia.Data;
using Torshia.Models;
using Torshia.Web.Services.Contracts;

namespace Torshia.Web.Services
{
    public class TasksService : ITasksService
    {
        private readonly TorshiaContext context;

        public TasksService(TorshiaContext context)
        {
            this.context = context;
        }

        public IQueryable<Task> All()
        {
            return this.context.Tasks;
        }
    }
}