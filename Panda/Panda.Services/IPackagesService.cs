using Panda.Domain;
using Panda.Models.Package;
using System;
using System.Collections.Generic;
using System.Text;
namespace Panda.Services
{
    public interface IPackagesService
    {
        IEnumerable<PackageViewModel> GetPackagesForUser(string username);
        IEnumerable<PackageViewModel> GetPackagesByShippingStatus(PackageStatus packageStatus);
        void CreatePackage(PackageCreationBindingModel packageCreationBindingModel);
        void Ship(string packageId);
        void Deliver(string packageId);
        PackageViewModel GetDetails(string packageId, string username, bool isAdmin);
        string Acquire(string packageId, string username);
        PackageReceiptDetailsModel GetInfoForReceipt(string packageId);

    }
}
