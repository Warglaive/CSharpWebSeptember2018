using System.Collections.Generic;
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
                Participants = participants
            };
            this.TorshiaDbContext.Tasks.Add(task);
            this.TorshiaDbContext.SaveChanges();
            return this.Redirect("/");
        }
    }
}