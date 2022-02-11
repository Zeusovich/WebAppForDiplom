using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.Interfaces;

namespace WebAppForDiplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderData orderData;

        public HomeController(IOrderData OrderData)
        {
            this.orderData = OrderData;
        }
        public IActionResult Index()
        {
            return View(orderData.GetOrders());
        }

        [HttpPost]
        public IActionResult SendOrder()
        {
            return Redirect("~/Home/Index");
        }
    }
}
