using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;
using Panda.Models.Package;
using Panda.Services;
using System;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;


        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = usersService.ReturnUsernames();

            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PackageCreationBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction();
            }

            packagesService.CreatePackage(bindingModel);

            return this.Redirect("/Packages/Pending");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Pending);

            return this.View(packagesViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Shipped);

            return this.View(packagesViewModel.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var packagesViewModel = packagesService.GetPackagesByShippingStatus(PackageStatus.Delivered);

            return this.View(packagesViewModel.ToList());
        }


        [HttpGet("/Packages/Ship/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            packagesService.Ship(id);

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            packagesService.Deliver(id);

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("Packages/Details/{id}")]
        [Authorize(Roles = "User, Admin")]
        public IActionResult Details(string id)
        {
            var isAdmin = this.User.IsInRole("Admin");
            var userName = this.User.Identity.Name;
            var packageView = packagesService.GetDetails(id, userName, isAdmin);

            if (packageView == null)
            {
                return this.Redirect("Home/Index");
            }

            return this.View(packageView);
        }

        [HttpGet("Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {

            var userName = this.User.Identity.Name;

            string acquiredPackageId = packagesService.Acquire(id, userName);

            if (acquiredPackageId == null)
            {
                return Redirect("/");
            }

            Receipt receipt = new Receipt()
            {
                IssuedOn = DateTime.UtcNow,
                Package = package,
                Recipient = package.Recipient,
                Fee = (decimal)package.Weight * 2.75m
            };



            this.context.Update(package);
            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();

            return this.Redirect("/Receipts/Index/");
        }
    }



}