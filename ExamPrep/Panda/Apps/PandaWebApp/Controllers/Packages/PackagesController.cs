using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;
using PandaWebApp.Models.Enums;
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
            var users = ApplicationDbContext.Users.ToList();

            var model = new PackageViewModel();

            foreach (var user in users)
            {
                model.UsersAllNames.Add(user.Username);
            }
            return this.View(model);
        }

        [HttpPost]
        public IHttpResponse Create(PackageViewModel model)
        {
            var recipient = this.ApplicationDbContext
            .Users
            .FirstOrDefault(x => x.Username == model.ChosenRecipient);

            //create package and set recipient to it
            var package = new Package
            {
                Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                Recipient = recipient,
                RecipientId = recipient.Id,
                Status = Status.Pending
                //EstimatedDeliveryDate = null
            };

            if (string.IsNullOrEmpty(package.Description) || string.IsNullOrWhiteSpace(package.Description) || package.Description == null)
            {
                return BadRequestError("Description can't be empty or null");
            }

            if (string.IsNullOrEmpty(package.ShippingAddress) || string.IsNullOrWhiteSpace(package.ShippingAddress) ||
                package.ShippingAddress == null)
            {
                return BadRequestError("Shipping Address can't be empty or null");
            }

            this.ApplicationDbContext.Packages.Add(package);
            this.ApplicationDbContext.SaveChanges();

            //add package to recipient's packages and to DB
            recipient.Packages.Add(package);

            //create receipt and add package and recipient to it
            var receipt = new Receipt
            {
                Fee = (decimal)(package.Weight * 2.67d),
                IssuedOn = DateTime.Now,
                Package = package,
                PackageId = package.Id,
                Recipient = recipient,
                RecipientId = recipient.Id
            };
            this.ApplicationDbContext.Receipts.Add(receipt);
            this.ApplicationDbContext.SaveChanges();
            //take info from model and take all recipients from dbContext
            return this.Redirect("/home/index");
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            //take needed package by its Id => pass it to the view => fill the view with info.
            var currentPackage = this.ApplicationDbContext
                .Packages
                .Include(x => x.Recipient)
                .FirstOrDefault(x => x.Id == id);

            if (currentPackage == null)
            {
                return BadRequestError("Product not found.");
            }
            //Casting with .To<viewModel> was causing error
            var viewModel = new PackageViewModel
            {
                Description = currentPackage.Description,
                ShippingAddress = currentPackage.ShippingAddress,
                Weight = currentPackage.Weight,
                Recipient = currentPackage.Recipient,
                Status = currentPackage.Status,
                EstimatedDeliveryDate = currentPackage.EstimatedDeliveryDate.ToString(CultureInfo.InvariantCulture)
            };
            if (currentPackage.Status == Status.Pending)
            {
                viewModel.EstimatedDeliveryDate = "N/A";
            }

            else if (currentPackage.Status == Status.Delivered)
            {
                viewModel.EstimatedDeliveryDate = "Delivered";
            }
            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Pending()
        {
            //take all pending packages, send to view /packages/pending
            var packages = this.ApplicationDbContext
                .Packages
                .Include(x => x.Recipient)
                .Where(x => x.Status == Status.Pending)
                .ToList();

            var viewModel = new LoggedInPackagesViewModel
            {
                PendingPackages = packages
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Shipped()
        {
            //take all pending packages, send to view /packages/pending
            var packages = this.ApplicationDbContext
                .Packages
                .Include(x => x.Recipient)
                .Where(x => x.Status == Status.Shipped)
                .ToList();

            var viewModel = new LoggedInPackagesViewModel
            {
                ShippedPackages = packages
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Delivered()
        {
            //take all pending packages, send to view /packages/pending
            var packages = this.ApplicationDbContext
                .Packages
                .Include(x => x.Recipient)
                .Where(x => x.Status == Status.Delivered)
                .ToList();

            var viewModel = new LoggedInPackagesViewModel
            {
                DeliveredPackages = packages
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Ship(int id)
        {
            if (!this.ApplicationDbContext.Packages.Any(x => x.Id == id))
            {
                return BadRequestError("No such package");
            }
            this.ApplicationDbContext
                .Packages.
                FirstOrDefault(x => x.Id == id)
                .Status = Status.Shipped;

            var days = new Random().Next(20, 40);

            this.ApplicationDbContext
                .Packages.FirstOrDefault(x => x.Id == id)
                .EstimatedDeliveryDate = DateTime.UtcNow.AddDays(days);

            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/packages/shipped");
        }

        [Authorize("Admin")]
        public IHttpResponse Deliver(int id)
        {
            if (!this.ApplicationDbContext.Packages.Any(x => x.Id == id))
            {
                return BadRequestError("No such package");
            }
            this.ApplicationDbContext
                .Packages.
                FirstOrDefault(x => x.Id == id)
                .Status = Status.Delivered;

            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/packages/delivered");
        }
    }
}