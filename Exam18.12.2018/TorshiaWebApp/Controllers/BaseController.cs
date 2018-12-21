using System.Collections.Generic;
using SIS.MvcFramework;
using TorshiaWebApp.Data;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.TorshiaDbContext = new TorshiaDbContext();
        }

        public TorshiaDbContext TorshiaDbContext { get; set; }
    }
}