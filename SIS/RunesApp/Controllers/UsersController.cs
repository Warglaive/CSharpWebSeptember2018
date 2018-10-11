using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace RunesApp.Controllers
{
    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View();
        }
        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View();
        }
    }
}