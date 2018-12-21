using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MUSACAWEbApp.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }
        [Key]
        public int Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public ICollection<Order> Orders { get; set; }

        public User Cashier { get; set; }
        public int CashierId { get; set; }
    }
}
