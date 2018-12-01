using System;
using System.ComponentModel.DataAnnotations;

namespace PandaWebApp.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public decimal Fee { get; set; }
        public DateTime IssuedOn { get; set; }

        public User Recipient { get; set; }
        public int RecipientId { get; set; }

        public Package Package { get; set; }
        public int PackageId { get; set; }
    }
}