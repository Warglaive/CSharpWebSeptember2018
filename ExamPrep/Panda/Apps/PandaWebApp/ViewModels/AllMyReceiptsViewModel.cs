using System.Collections.Generic;

namespace PandaWebApp.ViewModels
{
    public class AllMyReceiptsViewModel
    {
        public AllMyReceiptsViewModel()
        {
            this.ReceiptViewModels = new List<ReceiptViewModel>();
        }
        public ICollection<ReceiptViewModel> ReceiptViewModels { get; set; }
    }
}
