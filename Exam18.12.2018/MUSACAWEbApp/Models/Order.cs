using System.ComponentModel.DataAnnotations;
using MUSACAWEbApp.Models.Enums;

namespace MUSACAWEbApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Status Status { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public User Cashier { get; set; }
        public int CashierId { get; set; }
    }
}