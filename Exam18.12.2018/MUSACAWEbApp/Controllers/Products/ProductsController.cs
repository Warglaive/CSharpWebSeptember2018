using System.Linq;
using MUSACAWEbApp.Models;
using MUSACAWEbApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MUSACAWEbApp.Controllers.Products
{
    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IHttpResponse Create(ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Picture = model.Picture,
                Price = model.Price,
                Barcode = model.Barcode
            };
            this.ApplicationDbContext.Products.Add(product);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse All()
        {
            var allProducts = this.ApplicationDbContext.Products.ToList();
            var viewModel = new ProductViewModel
            {
                Products = allProducts
            };
            return this.View(viewModel);
        }
    }
}