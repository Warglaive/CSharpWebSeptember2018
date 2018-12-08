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

            var user = this.ApplicationDbContext
                .Users.Include(x => x.Packages)
                .FirstOrDefault(x => x.Username == this.User.Username);
            //take current user, take all his packages, send them to view

            if (!user.Packages.Any())
            {
                return this.BadRequestErrorWithView($"User: {user.Username} doesn't have any packages!");
            }
            //take all packages and split them to 3 ;

            var viewModel = new LoggedInPackagesViewModel
            {
                PendingPackages = this.ApplicationDbContext
                    .Packages
                    .Where(
                        x => x.Status == Status.Pending
                             &&
                             this.User.Username == x.Recipient.Username)
                    .ToList(),


                ShippedPackages = this.ApplicationDbContext.Packages
                    .Where(x => x.Status == Status.Shipped
                                &&
                                this.User.Username == x.Recipient.Username)
                    .ToList(),

                DeliveredPackages = this.ApplicationDbContext.Packages
                    .Where(x => x.Status == Status.Delivered
                                && this.User.Username == x.Recipient.Username)
                    .ToList()
            };

            //SHOULD BE SPLITTED, OTHERWISE ERROR AND NAMED ViewModel
            return this.View("/Home/LoggedInIndex", viewModel);
            //User template
        }
    }
}