using System;
using SIS.Framework;
using Torshia.Data;
using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.Web
{
    public class Launcher
    {
        public static void Main()
        {
            var context = new TorshiaContext();
            for (int i = 0; i < 6; i++)
            {
                context.Reports.Add(new Report
                {
                    Status = Status.Completed,
                    TaskId = 2,
                    ReporterId = 1,
                    ReportedOn = DateTime.Now
                });
            }

            context.SaveChanges();
            WebHost.Start(new StartUp());
        }
    }
}