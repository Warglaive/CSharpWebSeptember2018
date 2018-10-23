using System.Collections.Generic;

namespace CakesApp.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}