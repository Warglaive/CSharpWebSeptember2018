using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PandaWebApp.Models;
using PandaWebApp.Models.Enums;

namespace PandaWebApp.ViewModels
{
    public class PackageViewModel
    {
        public PackageViewModel()
        {
            this.UsersAllNames = new HashSet<string>();
        }
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string EstimatedDeliveryDate { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public User Recipient { get; set; }

        public string ChosenRecipient { get; set; }

        public ICollection<string> UsersAllNames { get; set; }

        public Status Status { get; set; }
    }
}