using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMash.App.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet("/Home/Index")]
        public IHttpResponse Index()
        {
            return this.View("Home/Index");
        }
        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.View("Home/Index");
        }
    }
}