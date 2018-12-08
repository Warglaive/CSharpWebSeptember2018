using SIS.HTTP.Responses;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            return this.Redirect("/Home/LoggedInIndex");
        }

        public IHttpResponse LoggedInIndex()
        {
            return this.View();
        }
    }
}