using System.Collections.Generic;
using PandaWebApp.Models;

namespace PandaWebApp.ViewModels
{
    public class LoggedInPackagesViewModel
    {
        public LoggedInPackagesViewModel()
        {
            this.PendingPackages = new List<Package>();
            this.ShippedPackages = new List<Package>();
            this.DeliveredPackages = new List<Package>();
        }
        public IEnumerable<Package> PendingPackages { get; set; }
        public IEnumerable<Package> ShippedPackages { get; set; }
        public IEnumerable<Package> DeliveredPackages { get; set; }
    }
}