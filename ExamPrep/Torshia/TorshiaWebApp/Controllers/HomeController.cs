using System;
using SIS.HTTP.Responses;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            Console.WriteLine(this.User.Username);
            return this.View();

            //return this.View("/Home/LoggedInIndex");
        }
    }
}