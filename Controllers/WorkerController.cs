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
            return View(orderData.GetOrdersForWorker(User.Identity.Name));
        }
        /// <summary>
        /// Обновляет статус заявки
        /// </summary>
        /// <returns></returns>     
        public IActionResult TakeOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TakeOrderByNumber(int id)
        {
            orderData.TakeOrder(id);
            return Redirect("/Worker/Index");
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
        public IActionResult SendReport(int id)
        {
            orderData.SendReadyOrder(id);
            return Redirect("~/Worker/Index");
        }

        public IActionResult MyReports()
        {
            return View(orderData.GetReadyOrders(User.Identity.Name));
        }





    }
}
