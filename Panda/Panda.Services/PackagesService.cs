using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Models.Package;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext context;

        public PackagesService(PandaDbContext context)
        {
            this.context = context;
        }


        private Package GetPackage(string packageId)
        {
            return context.Packages.Include(x => x.Recipient).SingleOrDefault(x => x.Id == packageId);
        }

        public string Acquire(string packageId, string username)
        {
            var package = GetPackage(packageId);

            if (package == null)
            {
                return null;
            }

            //TODO: Find a better way to confirm user. Maybe with email or user id
            if (package.ShippingStatus != PackageStatus.Delivered || package.Recipient.UserName != username
                || package.ShippingStatus == PackageStatus.Acquired)
            {
                return null;
            }

            package.ShippingStatus = PackageStatus.Acquired;

            context.Update(package);
            context.SaveChanges();

            return package.Id;
        }

        public void CreatePackage(PackageCreationBindingModel packageCreationBindingModel)
        {
            Package package = new Package
            {
                Description = packageCreationBindingModel.Description,
                Weight = packageCreationBindingModel.Weight,
                Recipient = context.Users.SingleOrDefault(user => user.UserName == packageCreationBindingModel.Recipient),
                ShippingAddress = packageCreationBindingModel.ShippingAddress,
                ShippingStatus = PackageStatus.Pending
            };

            context.Packages.Add(package);
            context.SaveChanges();
        }

        public void Deliver(string packageId)
        {
            Package package = context.Packages.Find(packageId);
            package.ShippingStatus = PackageStatus.Delivered;

            context.Update(package);
            context.SaveChanges();
        }

        public PackageViewModel GetDetails(string packageId, string username, bool isAdmin)
        {
            var package = GetPackage(packageId);

            if (package == null)
            {
                return null;
            }

            var packageView = new PackageViewModel()
            {
                Id = package.Id,
                Description = package.Description,
                EstimatedDeliveryDate = package.EstimatedDeliveryDate == null ? "N/A" : package.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Recipient = package.Recipient.UserName,
                ShippingAddress = package.ShippingAddress,
                Weight = package.Weight,
                Status = package.ShippingStatus.ToString()

            };

            if (!isAdmin && packageView.Recipient != username)
            {
                return null;
            }

            return packageView;

        }

        public PackageReceiptDetailsModel GetInfoForReceipt(string packageId)
        {
            var package = GetPackage(packageId);

            var packageDto = new PackageReceiptDetailsModel
            {
                PackageId = package.Id,
                RecipientId = package.RecipientId,
                Weight = package.Weight

            };

            return packageDto;
        }

        public IEnumerable<PackageViewModel> GetPackagesByShippingStatus(PackageStatus packageStatus)
        {
            var packagesList = context.Packages
                .Where(package => package.ShippingStatus == packageStatus)
                .Select(package =>
                       new PackageViewModel
                       {
                           Id = package.Id,
                           Description = package.Description,
                           Weight = package.Weight,
                           ShippingAddress = package.ShippingAddress,
                           Recipient = package.Recipient.UserName
                       }).ToList();

            return packagesList;

        }

        public IEnumerable<PackageViewModel> GetPackagesForUser(string username)
        {
            var packagesList = context.Packages.Where(x => x.Recipient.UserName == username)
               .Select(x => new PackageViewModel
               {
                   Id = x.Id,
                   Description = x.Description,
                   Status = x.ShippingStatus.ToString()
               })
               .ToList();

            return packagesList;
        }

        public void Ship(string packageId)
        {
            Package package = context.Packages.Find(packageId);
            package.ShippingStatus = PackageStatus.Shipped;

            Random random = new Random();

            DateTime estimatedDelivery = DateTime.UtcNow.AddDays(random.Next(20, 40));
            package.EstimatedDeliveryDate = estimatedDelivery;

            context.Update(package);
            context.SaveChanges();
        }
    }
}
