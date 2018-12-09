using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers.Tasks
{
    public class TasksController : BaseController
    {
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Create(TaskViewModel model)
        {
            var participants = new List<Participant>();
            foreach (var name in model.Participants.Split(","))
            {
                participants.Add(new Participant { Name = name.Trim() });
            }

            var affectedSectors = new List<Sector>();

            if (model.SectorCustomers != null)
            {
                affectedSectors.Add(new Sector { Name = model.SectorCustomers });
            }
            if (model.SectorFinances != null)
            {
                affectedSectors.Add(new Sector { Name = model.SectorFinances });
            }
            if (model.SectorInternal != null)
            {
                affectedSectors.Add(new Sector { Name = model.SectorInternal });
            }
            if (model.SectorManagement != null)
            {
                affectedSectors.Add(new Sector { Name = model.SectorManagement });
            }
            if (model.SectorMarketing != null)
            {
                affectedSectors.Add(new Sector { Name = model.SectorMarketing });
            }

            var task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                AffectedSectors = affectedSectors,
                DueDate = model.DueDate,
                Participants = participants,
                Level = affectedSectors.Count
            };
            //save level to server
            this.TasksStorage.Add(task);
            //save everything else to Db
            this.TorshiaDbContext.Tasks.Add(task);
            this.TorshiaDbContext.SaveChanges();
            return this.Redirect("/");
        }


        public IHttpResponse Details(string id)
        {
            var task = this.TorshiaDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            task.Level = this.TasksStorage.FirstOrDefault(x => x.Id == id).Level;
            var participants = string.Empty;

            var viewModel = new TaskViewModel
            {
                Level = task.Level,
                Title = task.Title,
                DueDate = task.DueDate,
                Participants = task.Participants

            };
            return this.View();
        }
    }
}