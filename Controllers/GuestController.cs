using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Controllers
{
    public class GuestController : Controller
    {
        private readonly IOrderData orderData;
        public GuestController(IOrderData OrderData)
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
        public IActionResult PreparationOfOrder(Order order)
        {
            order.ResponceTime = DateTime.Now;
            order.Status = "Отправлена";
            order.Name = User.Identity.Name;
            orderData.AddOrder(order);
            return Redirect("/Guest/Index");
        }
        /// <summary>
        /// возвращает view GuestOrders
        /// </summary>
        /// <returns></returns>
        public IActionResult GuestOrders()
        {
            return View(orderData.GetOrders());
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
        public IActionResult SendFeedback(Order order)
        {
            orderData.Feedback(order.Id, order.Feedback, order.Recommend);
            return Redirect("~/Guest/Index");
        }
    }
}
