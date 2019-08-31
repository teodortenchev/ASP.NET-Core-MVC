using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.App.Models.Package;
using Panda.Data;
using Panda.Domain;
using System;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        //TODO: Better create a service. Only doing like this to save time right now
        private readonly PandaDbContext context;



        public PackagesController(PandaDbContext context)
        {
            this.context = context;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this.context.Users.ToList();

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

            Package package = new Package
            {
                Description = bindingModel.Description,
                Weight = bindingModel.Weight,
                Recipient = this.context.Users.SingleOrDefault(user => user.UserName == bindingModel.Recipient),
                ShippingAddress = bindingModel.ShippingAddress,
                ShippingStatus = PackageStatus.Pending
            };

            context.Packages.Add(package);
            context.SaveChanges();

            return this.Redirect("/Packages/Pending");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var packagesViewModel = context.Packages
                .Where(package => package.ShippingStatus == PackageStatus.Pending)
                .Select(package =>
                       new PackageViewModel
                       {
                           Id = package.Id,
                           Description = package.Description,
                           Weight = package.Weight,
                           ShippingAddress = package.ShippingAddress,
                           Recipient = package.Recipient.UserName
                       });


            return this.View(packagesViewModel.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            var packagesViewModel = context.Packages
                .Where(package => package.ShippingStatus == PackageStatus.Shipped)
                .Select(package =>
                       new PackageViewModel
                       {
                           Id = package.Id,
                           Description = package.Description,
                           Weight = package.Weight,
                           EstimatedDeliveryDate = package.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy"),
                           Recipient = package.Recipient.UserName
                       });


            return this.View(packagesViewModel.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var packagesViewModel = context.Packages
                .Where(package => package.ShippingStatus == PackageStatus.Delivered || package.ShippingStatus == PackageStatus.Acquired)
                .Select(package =>
                       new PackageViewModel
                       {
                           Id = package.Id,
                           Description = package.Description,
                           Weight = package.Weight,
                           ShippingAddress = package.ShippingAddress,
                           Recipient = package.Recipient.UserName
                       });


            return this.View(packagesViewModel.ToList());
        }


        [HttpGet("/Packages/Ship/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            Package package = this.context.Packages.Find(id);
            package.ShippingStatus = PackageStatus.Shipped;

            Random random = new Random();

            DateTime estimatedDelivery = DateTime.UtcNow.AddDays(random.Next(20, 40));
            package.EstimatedDeliveryDate = estimatedDelivery;


            this.context.Update(package);
            this.context.SaveChanges();

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            Package package = this.context.Packages.Find(id);
            package.ShippingStatus = PackageStatus.Delivered;

            this.context.Update(package);
            this.context.SaveChanges();

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("Packages/Details/{id}")]
        [Authorize(Roles = "User, Admin")]
        public IActionResult Details(string id)
        {
            Package package = context.Packages.Include(x => x.Recipient).SingleOrDefault(x => x.Id == id);

            if (package == null)
            {
                return this.Redirect("Home/Index");
            }

            if (this.User.IsInRole("User") && package.Recipient.UserName != this.User.Identity.Name)
            {
                return this.Redirect("Home/Index");
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


            return this.View(packageView);
        }

        [HttpGet("Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            Package package = context.Packages.Include(x => x.Recipient).SingleOrDefault(x => x.Id == id);

            if (package == null)
            {
                this.Redirect("/");
            }

            //TODO: Find a better way to confirm user. Maybe with email or user id
            if (package.ShippingStatus != PackageStatus.Delivered || package.Recipient.UserName != this.User.Identity.Name
                || package.ShippingStatus == PackageStatus.Acquired)
            {
                return this.Redirect("/");
            }

            package.ShippingStatus = PackageStatus.Acquired;

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