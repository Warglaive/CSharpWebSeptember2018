using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace CakesApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View("Index");
        }
    }
}