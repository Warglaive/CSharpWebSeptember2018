using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MUSACAWEbApp.Models;
using MUSACAWEbApp.Models.Enums;
using MUSACAWEbApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MUSACAWEbApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            return this.Redirect("/Home/LoggedInIndex");
        }

        [HttpGet]
        public IHttpResponse LoggedInIndex()
        {
            var activeProducts = this.ApplicationDbContext.Orders.Include(x => x.Product).Where(x => x.Status == Status.Active).ToList();

            var viewModel = new OrderViewModel
            {
                ActiveOrders = activeProducts,
                TotalPrice = activeProducts.Sum(x => x.Product.Price)

            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse LoggedInIndex(ProductViewModel model)
        {
            var cashier = this.ApplicationDbContext.Users.FirstOrDefault(x => x.Username == this.User.Username);
            var product = this.ApplicationDbContext.Products.FirstOrDefault(x => x.Barcode == model.Barcode);
            if (product == null)
            {
                return this.View();
            }
            var order = new Order
            {
                Cashier = cashier,
                Product = product,
                Quantity = model.Quantity,
                Status = Status.Active
            };

            this.ApplicationDbContext.Orders.Add(order);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/");
        }
    }
}
