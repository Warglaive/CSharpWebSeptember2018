using System.Collections.Generic;

namespace PandaWebApp.ViewModels
{
    public class PackageViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }
    }
}