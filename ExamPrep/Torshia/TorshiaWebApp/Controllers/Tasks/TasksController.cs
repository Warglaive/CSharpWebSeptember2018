using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.Models.Enums;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers.Tasks
{
    public class TasksController : BaseController
    {
        [Authorize]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IHttpResponse Create(TaskViewModel model)
        {
            var participants = model.Participants;

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

            if (string.IsNullOrEmpty(model.Participants) || string.IsNullOrWhiteSpace(model.Participants))
            {
                return BadRequestError("Participants cant be empty");
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
            //save everything else to Db
            this.TorshiaDbContext.Tasks.Add(task);
            this.TorshiaDbContext.SaveChanges();
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Details(string id)
        {
            //take level for current Task
            var level = this.TorshiaDbContext.AffectedSectors.Count(x => x.TaskId == id);

            var task = this.TorshiaDbContext.Tasks
                .Include(x => x.AffectedSectors)
                .FirstOrDefault(x => x.Id == id);

            var affectedSectorsNames = new List<string>();

            foreach (var sector in task.AffectedSectors)
            {
                affectedSectorsNames.Add(sector.Name);
            }

            if (task.Participants == null)
            {
                task.Participants = string.Empty;
            }
            var formattedSectors = string.Join(", ", affectedSectorsNames);
            var viewModel = new TaskViewModel
            {
                Level = level,
                Title = task.Title,
                DueDate = task.DueDate,
                Participants = task.Participants,
                Description = task.Description,
                AffectedSectors = formattedSectors

            };
            return this.View(viewModel);
        }

        [Authorize]
        public IHttpResponse Report(string id)
        {
            var task = TorshiaDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            task.IsReported = true;

            var currentUser = this.TorshiaDbContext
                .Users
                .FirstOrDefault(x => x.Username == this.User.Username);

            //make custom random, 25 == 1/4 of 100
            var randomDigit = new Random().Next(1, 100);

            var report = new Report
            {
                ReportedOn = DateTime.UtcNow,
                Reporter = currentUser,
                ReporterId = currentUser.Id,
                Task = task,
                TaskId = task.Id,
                Status = Status.Completed

            };
            if (randomDigit <= 25)
            {
                report.Status = Status.Archived;
            }
            this.TorshiaDbContext.Reports.Add(report);
            this.TorshiaDbContext.SaveChanges();
            //TODO:SET Isreported=true IN DB, CREATE REPORT On Report click
            //TODO CREATE All reports page, and details about report
            return this.Redirect("/");
        }
    }
}