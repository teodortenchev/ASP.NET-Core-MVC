using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Models.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IPackagesService packagesService;
        private readonly PandaDbContext context;

        public ReceiptService(IPackagesService packagesService, PandaDbContext context)
        {
            this.packagesService = packagesService;
            this.context = context;
        }

        public void GenerateReceipt(string packageId)
        {
            var packageDetails = packagesService.GetInfoForReceipt(packageId);

            Receipt receipt = new Receipt()
            {
                IssuedOn = DateTime.UtcNow,
                PackageId = packageDetails.PackageId,
                RecipientId = packageDetails.RecipientId,
                Fee = (decimal)packageDetails.Weight * 2.75m
            };
            
            context.Receipts.Add(receipt);
            context.SaveChanges();

        }

        public ReceiptViewModel GetDetails(string receiptId, string username)
        {
            Receipt receipt = context.Receipts.Where(x => x.Recipient.UserName == username && x.Id == receiptId).Include(x => x.Recipient).Include(x => x.Package).SingleOrDefault();

            if (receipt == null)
            {
                return null;
            }

            var receiptViewModel = new ReceiptViewModel()
            {
                Id = receipt.Id,
                Fee = receipt.Fee,
                IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Recipient = receipt.Recipient.UserName,
                Package = new Models.Package.PackageViewModel
                {
                    Description = receipt.Package.Description,
                    ShippingAddress = receipt.Package.ShippingAddress,
                    Weight = receipt.Package.Weight
                }
            };

            return receiptViewModel;
        }

        public IEnumerable<ReceiptViewModel> GetReceiptsForUser(string username)
        {
            var receiptsList = context.Receipts.Where(x => x.Recipient.UserName == username)
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Recipient = x.Recipient.UserName,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    Fee = x.Fee
                })
                .ToList();

            return receiptsList;
        }
    }
}
