using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace RunesApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            if (this.IsAuthenticated(request))
            {
                var username = request.FormData["username"];
                this.ViewBag["username"] = username.ToString();
                return this.View("indexloggedin");
            }
            return this.View();
        }
    }
}