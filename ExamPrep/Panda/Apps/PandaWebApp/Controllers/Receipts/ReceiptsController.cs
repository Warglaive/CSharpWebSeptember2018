using SIS.HTTP.Responses;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}