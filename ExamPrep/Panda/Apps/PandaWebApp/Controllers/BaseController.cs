using PandaWebApp.Data;

namespace PandaWebApp.Controllers
{
    using SIS.MvcFramework;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.ApplicationDbContext = new PandaDbContext();
        }

        protected PandaDbContext ApplicationDbContext;
    }
}