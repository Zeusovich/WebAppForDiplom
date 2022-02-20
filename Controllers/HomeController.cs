using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

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
            ViewBag.RoleAdmin = new Claim(ClaimTypes.Role, "Administrator");
            ViewBag.RoleBoss = new Claim(ClaimTypes.Role, "Boss");
            ViewBag.RoleWorker = new Claim(ClaimTypes.Role, "Worker");
            ViewBag.RoleGuest = new Claim(ClaimTypes.Role, "Guest");
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View(orderData.GetOrders());
        }
        
        [HttpPost]
        [Authorize(Policy = "Guest")]
        public IActionResult SendOrder()
        {
            return Redirect("~/Home/Index");
        }
    }
}
