using System.Collections.Generic;

namespace Torshia.Web.ViewModels
{
    public class TaskViewModelWrapper
    {
        public TaskViewModelWrapper()
        {
            this.TaskViewModels = new List<TaskViewModel>();
        }
        public ICollection<TaskViewModel> TaskViewModels { get; set; }
    }
}