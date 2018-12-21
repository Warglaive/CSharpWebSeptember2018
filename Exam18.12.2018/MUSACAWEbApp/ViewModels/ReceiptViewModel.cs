using System;
using System.Collections.Generic;
using System.Text;
using MUSACAWEbApp.Models;

namespace MUSACAWEbApp.ViewModels
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel()
        {
            this.Orders = new List<Order>();
            this.Receipts = new List<Receipt>();
        }
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; }
        public decimal Total { get; set; }
        public DateTime IssuedOn { get; set; }
        public User Cashier { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
