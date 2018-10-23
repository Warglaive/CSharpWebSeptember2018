using System;

namespace CakesApp.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }

        public Product Product { get; set; }
        public string ProductId { get; set; }
    }
}