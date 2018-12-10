using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
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
        [Authorize]
        public IHttpResponse LoggedInIndex()
        {
            var tasks = this.TorshiaDbContext.Tasks.Where(x => x.IsReported == false);
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
                    Id = task.Id,
                    Title = task.Title,
                    Level = task.Level
                };
                viewModel.AllTasks.Add(taskViewModel);
            }
            return this.View(viewModel);
        }
    }
}