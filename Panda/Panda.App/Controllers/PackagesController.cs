using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.Domain;
using Panda.Models.Package;
using Panda.Services;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;
        private readonly IReceiptService receiptService;


        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Recipients"] = usersService.ReturnUsernames();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PackageCreationBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction();
            }

            packagesService.CreatePackage(bindingModel);

            return Redirect("/Packages/Pending");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Pending);

            return View(packagesViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Shipped);

            return View(packagesViewModel.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Delivered);

            return View(packagesViewModel.ToList());
        }


        [HttpGet("/Packages/Ship/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            packagesService.Ship(id);

            return Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            packagesService.Deliver(id);

            return Redirect("/Packages/Delivered");
        }

        [HttpGet("Packages/Details/{id}")]
        [Authorize(Roles = "User, Admin")]
        public IActionResult Details(string id)
        {
            var isAdmin = User.IsInRole("Admin");
            var userName = User.Identity.Name;
            var packageView = packagesService.GetDetails(id, userName, isAdmin);

            if (packageView == null)
            {
                return Redirect("Home/Index");
            }

            return View(packageView);
        }

        [HttpGet("Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            var userName = User.Identity.Name;

            string acquiredPackageId = packagesService.Acquire(id, userName);

            if (acquiredPackageId == null)
            {
                return Redirect("/");
            }

            receiptService.GenerateReceipt(acquiredPackageId);

            return Redirect("/Receipts/Index/");
        }
    }



}