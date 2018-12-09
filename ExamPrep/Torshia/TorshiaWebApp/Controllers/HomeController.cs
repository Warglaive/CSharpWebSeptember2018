using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Responses;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            return this.Redirect("/Home/LoggedInIndex");
        }

        public IHttpResponse LoggedInIndex()
        {
            var tasks = this.TorshiaDbContext.Tasks;
            var affectedSectors = this.TorshiaDbContext.AffectedSectors;
            var viewModel = new TaskViewModel();

            foreach (var task in tasks)
            {
                foreach (var affectedSector in affectedSectors)
                {
                    if (task.Id == affectedSector.TaskId)
                    {
                        task.Level++;
                    }
                }
                var taskViewModel = new TaskViewModel
                {
                    Title = task.Title,
                    Level = task.Level
                };
                viewModel.AllTasks.Add(taskViewModel);
            }

            //for (int i = 0; i < viewModel.AllTasks.ToList().Count; i++)
            //{
            //    viewModel.AllTasks.ToList()[i]= null;
            //}
            return this.View(viewModel);
        }
    }
}