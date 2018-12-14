using SIS.HTTP.Responses;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}