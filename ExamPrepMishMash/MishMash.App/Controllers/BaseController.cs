using MishMash.App.Data;
using SIS.MvcFramework;

namespace MishMash.App.Controllers
{
    public class BaseController : Controller
    {
        public MishMashDbContext Db { get; set; }

        public BaseController()
        {
            this.Db = new MishMashDbContext();
        }
    }
}