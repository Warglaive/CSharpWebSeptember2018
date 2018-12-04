using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;

namespace PandaWebApp.Controllers.Receipts
{
    public class ReceiptsController : BaseController
    {
        public IHttpResponse Index()
        {
            var receipts = this.ApplicationDbContext.Receipts.Include(x => x.Recipient).Where(x => x.Recipient.Username == this.User.Username);
            var allReceipts = new AllMyReceiptsViewModel();
            foreach (var receipt in receipts)
            {
                var currentReceipt = new ReceiptViewModel
                {
                    Id = receipt.Id,
                    Fee = receipt.Fee,
                    IssuedOn = receipt.IssuedOn.ToString(CultureInfo.InvariantCulture),
                    Recipient = receipt.Recipient.Username
                };
                allReceipts.ReceiptViewModels.Add(currentReceipt);
            }
            return this.View(allReceipts);
        }
    }
}