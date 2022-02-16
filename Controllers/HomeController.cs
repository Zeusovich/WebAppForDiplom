using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.Interfaces;

namespace WebAppForDiplom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderData orderData;

        public HomeController(IOrderData OrderData)
        {
            this.orderData = OrderData;
        }
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View(orderData.GetOrders());
        }


        
        [HttpPost]
        [Authorize(Policy = "Administrator")]
        public IActionResult SendOrder()
        {
            return Redirect("~/Home/Index");
        }
    }
}
