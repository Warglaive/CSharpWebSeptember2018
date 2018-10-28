using SIS.Framework.ActionResults;
using Torshia.Web.Controllers.Base;

namespace Torshia.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}