using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers.Packages
{
    public class PackagesController : BaseController
    {
        [HttpGet("/packages/create")]
        public IHttpResponse Create()
        {
            var users = ApplicationDbContext.Users;
            var model = new UserViewModel();
            foreach (var user in users)
            {
                model.UsersAllNames.Add(user.Username);
            }
            return this.View(model);
        }

        [HttpPost]
        public IHttpResponse Create(PackageViewModel model)
        {
            //take info from model and take all recipients from dbContext
            return null;
        }
    }
}