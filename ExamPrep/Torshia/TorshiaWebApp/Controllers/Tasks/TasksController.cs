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
            var affectedSectors = new List<Sector>();
            foreach (var name in model.AffectedSectors)
            {
                affectedSectors.Add(new Sector { Name = name });
            }

            var participants = new List<Participant>();
            foreach (var name in model.Participants)
            {
                participants.Add(new Participant { Name = name });
            }

            var task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                AffectedSectors = affectedSectors,
                DueDate = model.DueDate,
                Participants = participants
            };
            return this.View();
        }
    }
}