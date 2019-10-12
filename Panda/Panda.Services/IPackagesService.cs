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
        PackageViewModel GetDetails(string packageId, string username, bool isUserRole);


    }
}
