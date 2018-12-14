﻿using MishMashWebApp.Data;
using SIS.MvcFramework;

namespace MishMashWebApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
        }

        protected ApplicationDbContext ApplicationDbContext { get; set; }
    }
}