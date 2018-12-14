using SIS.HTTP.Responses;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            //return channels
            return this.View("/Home/IndexLoggedIn");
        }
    }
}