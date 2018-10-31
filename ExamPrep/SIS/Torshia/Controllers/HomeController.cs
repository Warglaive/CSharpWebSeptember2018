using System.Collections.Generic;
using System.Linq;
using SIS.Framework.ActionResults;
using Torshia.Web.Controllers.Base;
using Torshia.Web.Services.Contracts;
using Torshia.Web.ViewModels;

namespace Torshia.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ITasksService tasksService;

        public HomeController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        public IActionResult Index()
        {
            var userLoggedIn = this.Identity != null;
            if (!userLoggedIn)
            {
                return this.View();
            }

            var tasks = tasksService.All().ToList();

            var wrapperViewModels = new List<TaskViewModelWrapper>();

            wrapperViewModels.Add(new TaskViewModelWrapper());

            for (var i = 0; i < tasks.Count; i++)
            {
                var lastAddedWrapper = wrapperViewModels.Last();
                lastAddedWrapper.TaskViewModels.Add(new TaskViewModel
                {
                    Title = tasks[i].Title,
                    Level = tasks[i].AffectedSectors.Count
                });

            }

            this.Model.Data["TaskViewModels"] = wrapperViewModels;
            return this.View();
        }
    }
}