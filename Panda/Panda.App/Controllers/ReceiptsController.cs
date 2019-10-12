using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.Data;
using Panda.Services;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly PandaDbContext context;

        public ReceiptsController(IReceiptService receiptService, PandaDbContext context)
        {
            this.receiptService = receiptService;
            this.context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            string username = User.Identity.Name;

            var receipts = receiptService.GetReceiptsForUser(username);

            return View(receipts);
        }


        [Authorize]
        [HttpGet("Receipts/Details/{id}")]
        public IActionResult Details(string id)
        {
            string username = User.Identity.Name;

            
            var receipt = receiptService.GetDetails(id, username);

            if(receipt == null)
            {
                return this.Redirect("/");
            }

            return this.View(receipt);
        }
    }
}