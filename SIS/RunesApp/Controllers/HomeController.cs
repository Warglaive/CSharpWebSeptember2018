using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace RunesApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View();
        }
    }
}