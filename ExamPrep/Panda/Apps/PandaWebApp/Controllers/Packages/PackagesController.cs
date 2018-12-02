using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers.Packages
{
    public class PackagesController : BaseController
    {
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Create(PackageViewModel model)
        {
            //take info from model and take all recipients from dbContext
            return null;
        }
    }
}