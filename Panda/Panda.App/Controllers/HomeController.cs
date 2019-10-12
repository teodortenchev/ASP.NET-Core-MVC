using Microsoft.AspNetCore.Mvc;
using Panda.Services;

namespace Panda.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPackagesService packagesService;

        public HomeController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public IActionResult Index()
        {
            var packagesList = packagesService.GetPackagesForUser(User.Identity.Name);

            return View(packagesList);
        }

     
        public IActionResult NotAuthorized()
        {
            return View();
        }

        
    }
}
