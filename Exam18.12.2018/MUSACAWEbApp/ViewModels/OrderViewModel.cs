using System.Collections.Generic;
using MUSACAWEbApp.Models;

namespace MUSACAWEbApp.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.ActiveOrders = new List<Order>();
        }
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
        public ICollection<Order> ActiveOrders { get; set; }
    }
}