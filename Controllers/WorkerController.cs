using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.Interfaces;

namespace WebAppForDiplom.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IOrderData orderData;

        public WorkerController(IOrderData OrderData)
        {
            this.orderData = OrderData;
        }
        public IActionResult Index()
        {
            return View(orderData.GetOrders());
        }
        /// <summary>
        /// Обновляет статус заявки
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TakeOrder()
        {
            return Redirect("~/Worker/Index");
        }
        /// <summary>
        /// Возвращает страницу MakeReport,удаляет заявку из списка
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MakeReport()
        {
            return View();
        }

        /// <summary>
        /// Отправляет данные отчета в контекст
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendReport()
        {
            return Redirect("~/Worker/Index");
        }

        public IActionResult MyReports()
        {
            return View();
        }





    }
}
