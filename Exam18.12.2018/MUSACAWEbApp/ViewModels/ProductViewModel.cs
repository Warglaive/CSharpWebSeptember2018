using System.Collections.Generic;
using MUSACAWEbApp.Models;

namespace MUSACAWEbApp.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.Products = new List<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int Barcode { get; set; }

        public ICollection<Product> Products { get; set; }
        public int Quantity { get; set; }
    }
}