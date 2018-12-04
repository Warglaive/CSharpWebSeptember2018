using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models.Enums;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    using SIS.HTTP.Responses;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            //take current user, take all his packages, send them to view
            var user = this.ApplicationDbContext
                .Users.
                Include(x => x.Packages)
                .FirstOrDefault(x => x.Username == this.User.Username);

            if (!user.Packages.Any())
            {
                return this.BadRequestErrorWithView($"User: {user.Username} doesn't have any packages!");
            }
            //take all packages and split them to 3 ;

            var packages = new UserPackagesViewModel
            {
                PendingPackages = user.Packages.Where(x => x.Status == Status.Pending),
                ShippedPackages = user.Packages.Where(x => x.Status == Status.Shipped),
                DeliveredPackages = user.Packages.Where(x => x.Status == Status.Delivered)
            };

            return this.View(packages);
        }
    }
}