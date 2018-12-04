namespace PandaWebApp.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public string IssuedOn { get; set; }

        public string RecipientUsername { get; set; }

        public string DeliveryAddress { get; set; }

        public double PackageWeight { get; set; }

        public string PackageDescription { get; set; }
    }
}