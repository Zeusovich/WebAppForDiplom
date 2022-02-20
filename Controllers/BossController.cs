using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.BusinessLogic;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Controllers
{
    [Authorize(Policy = "Boss")]
    public class BossController : Controller
    {
        private readonly IOrderData _orderData;        
        private readonly OptimizationAlgorithm _optimizationAlgorithm;
        public BossController(IOrderData orderData,OptimizationAlgorithm optimizationAlgorithm)
        {
            _optimizationAlgorithm = optimizationAlgorithm;
            this._orderData = orderData;
        }
        /// <summary>
        /// Возвращает отправленные заявки(пустые)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_orderData.GetOrdersWithoutWorker());
        }
        /// <summary>
        /// Представление для отправки заявки рабочему
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkerForm()
        {
            ViewBag.Worker1 = "worker1";
            ViewBag.Worker2 = "worker2";
            ViewBag.Worker3 = "worker3";
            return View();
        }

        [HttpPost]
        public IActionResult SendOrderToWorker(int id,string workerName)
        {
            _orderData.AddWorkerName(id, workerName);
            return Redirect("/Boss/Index");
        }

        public IActionResult GetReadyReports()
        {
            return View(_orderData.GetReadyOrders());
        }

        public IActionResult RateOrderPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RateOrder(Order order)
        {
            _orderData.BossRate(order.Id,order.ValueBeginOfWork,order.ValueEndOfWork);
            return Redirect("/Boss/GetReadyReports");
        }
        public IActionResult GetResults()
        {
            _optimizationAlgorithm.Val(_orderData.GetValues());
            return View(_orderData.GetOrders());
        }

    }
}
