using Panda.Data;
using Panda.Domain;
using System;

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
    }
}
