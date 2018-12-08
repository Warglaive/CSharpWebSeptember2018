using SIS.MvcFramework;
using TorshiaWebApp.Data;

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