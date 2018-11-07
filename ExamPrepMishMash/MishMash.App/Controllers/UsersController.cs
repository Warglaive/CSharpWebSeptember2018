using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMash.App.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("/Users/Login")]
        public IHttpResponse Login()
        {
            return this.View("Users/Login");
        }
        [HttpGet("/Users/Register")]
        public IHttpResponse Register()
        {
            return this.View("Users/Register");
        }
    }
}