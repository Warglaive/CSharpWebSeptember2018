using System.ComponentModel.DataAnnotations;
using PandaWebApp.Models;
using PandaWebApp.Models.Enums;

namespace PandaWebApp.ViewModels
{
    public class PackageViewModel
    {
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string EstimatedDeliveryDate { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public User Recipient { get; set; }

        public Status Status { get; set; }
    }
}