using MUSACAWEbApp.Data;
using SIS.MvcFramework;

namespace MUSACAWEbApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext ApplicationDbContext { get; set; }
    }
}
