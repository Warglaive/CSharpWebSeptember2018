using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MUSACAWEbApp.Models;
using MUSACAWEbApp.Models.Enums;
using MUSACAWEbApp.ViewModels;
using SIS.HTTP.Responses;

namespace MUSACAWEbApp.Controllers.Receipts
{
    public class ReceiptsController : BaseController
    {
        public IHttpResponse Create()
        {
            var currentOrders = this.ApplicationDbContext.Orders.Where(x => x.Status == Status.Active).ToList();
            var cashier = this.ApplicationDbContext.Users.FirstOrDefault(x => x.Username == this.User.Username);

            foreach (var currentOrder in currentOrders)
            {
                currentOrder.Status = Status.Completed;
            }

            var receipt = new Receipt
            {
                Cashier = cashier,
                CashierId = cashier.Id,
                IssuedOn = DateTime.UtcNow,
                Orders = currentOrders
            };
            this.ApplicationDbContext.Receipts.Add(receipt);
            this.ApplicationDbContext.SaveChanges();
            //may cause BUG
            return this.Redirect($"/receipts/details?id={receipt.Id}");
        }

        public IHttpResponse Details(int id)
        {
            var currentReceipt = this.ApplicationDbContext.Receipts.Include(x => x.Cashier).Include(x => x.Orders)
                .ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);

            var viewModel = new ReceiptViewModel
            {
                Id = currentReceipt.Id,
                IssuedOn = currentReceipt.IssuedOn,
                Cashier = currentReceipt.Cashier,
                Total = currentReceipt.Orders.Sum(x => x.Product.Price),
                Orders = currentReceipt.Orders
            };
            return this.View(viewModel);
        }

        public IHttpResponse All()
        {
            var receipts = this.ApplicationDbContext.Receipts
                .Include(x => x.Cashier).Include(x => x.Orders).ThenInclude(x => x.Product).ToList();

            var viewModel = new ReceiptViewModel
            {
                Receipts = receipts
            };
            foreach (var receipt in viewModel.Receipts)
            {
                   // receipt.
            }
            return this.View(viewModel);
        }
    }
}