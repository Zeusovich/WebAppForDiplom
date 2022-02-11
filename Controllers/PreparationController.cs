using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Controllers
{
    public class PreparationController : Controller
    {
        private readonly IOrderData orderData;
        public PreparationController(IOrderData OrderData)
        {
            this.orderData = OrderData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Добавляет заявку в контекст
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PreparationOfOrder(string Name)
        {
            orderData.AddOrder(Name);
            return Redirect("~/Home/Index");
        }
        /// <summary>
        /// возвращает view GuestOrders
        /// </summary>
        /// <returns></returns>
        public IActionResult GuestOrders()
        {
            return View();
        }

        /// <summary>
        /// Возвращает View Feedback
        /// </summary>
        /// <returns></returns>
        public IActionResult Feedback()
        {
            return View();
        }

        /// <summary>
        /// Метод отправляет отзыв в контекст
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendFeedback()
        {
            return Redirect("~/Preparation/Index");
        }
    }
}
