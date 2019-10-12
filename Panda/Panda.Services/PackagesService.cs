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

        public void CreatePackage(PackageCreationBindingModel packageCreationBindingModel)
        {
            Package package = new Package
            {
                Description = packageCreationBindingModel.Description,
                Weight = packageCreationBindingModel.Weight,
                Recipient = this.context.Users.SingleOrDefault(user => user.UserName == packageCreationBindingModel.Recipient),
                ShippingAddress = packageCreationBindingModel.ShippingAddress,
                ShippingStatus = PackageStatus.Pending
            };

            context.Packages.Add(package);
            context.SaveChanges();
        }

        public void Deliver(string packageId)
        {
            Package package = this.context.Packages.Find(packageId);
            package.ShippingStatus = PackageStatus.Delivered;

            this.context.Update(package);
            this.context.SaveChanges();
        }

        public PackageViewModel GetDetails(string packageId, string username, bool isAdmin)
        {
            Package package = context.Packages.Include(x => x.Recipient).SingleOrDefault(x => x.Id == packageId);

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
            Package package = this.context.Packages.Find(packageId);
            package.ShippingStatus = PackageStatus.Shipped;

            Random random = new Random();

            DateTime estimatedDelivery = DateTime.UtcNow.AddDays(random.Next(20, 40));
            package.EstimatedDeliveryDate = estimatedDelivery;

            this.context.Update(package);
            this.context.SaveChanges();
        }
    }
}
