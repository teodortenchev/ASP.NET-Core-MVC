using Microsoft.AspNetCore.Mvc;
using Panda.App.Models.Package;
using Panda.Data;
using System.Linq;

namespace Panda.App.Controllers
{
    public class HomeController : Controller
    {
        //TODO: Better create a service. Only doing like this to save time right now
        private readonly PandaDbContext context;



        public HomeController(PandaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var packagesList = context.Packages.Where(x => x.Recipient.UserName == this.User.Identity.Name)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Status = x.ShippingStatus.ToString()
                })
                .ToList();

            return View(packagesList);
        }

     
        public IActionResult NotAuthorized()
        {
            return this.View();
        }

        
    }
}
