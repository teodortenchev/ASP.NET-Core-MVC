using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.App.Models.Receipt;
using Panda.Data;
using Panda.Domain;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        //TODO: Better create a service. Only doing like this to save time right now
        private readonly PandaDbContext context;

        public ReceiptsController(PandaDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var receiptsList = context.Receipts.Where(x => x.Recipient.UserName == this.User.Identity.Name)
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Recipient = x.Recipient.UserName,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    Fee = x.Fee
                })
                .ToList();

            return View(receiptsList);
        }


        [Authorize]
        [HttpGet("Receipts/Details/{id}")]
        public IActionResult Details(string id)
        {
            Receipt receipt = context.Receipts.Where(x => x.Recipient.UserName == this.User.Identity.Name && x.Id == id).Include(x => x.Recipient).Include(x => x.Package).SingleOrDefault();

            if(receipt == null)
            {
                return this.Redirect("/");
            }

            var receiptViewModel = new ReceiptViewModel()
            {
                Id = receipt.Id,
                Fee = receipt.Fee,
                IssuedOn  = receipt.IssuedOn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Recipient = receipt.Recipient.UserName,
                Package = new Models.Package.PackageViewModel
                {
                    Description = receipt.Package.Description,
                    ShippingAddress = receipt.Package.ShippingAddress,
                    Weight = receipt.Package.Weight                    
                }
            };

            return this.View(receiptViewModel);
        }
    }
}