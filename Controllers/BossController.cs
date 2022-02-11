using Microsoft.AspNetCore.Mvc;
using WebAppForDiplom.Interfaces;

namespace WebAppForDiplom.Controllers
{
    public class BossController : Controller
    {
        private readonly IOrderData _iOrderData;

        public BossController(IOrderData orderData)
        {
            this._iOrderData = orderData;
        }
        /// <summary>
        /// Возвращает отправленные заявки(пустые)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_iOrderData.GetOrders());
        }

        public IActionResult GetReadyReports()
        {
            return View();
        }

        public IActionResult GetResults()
        {
            return View();
        }

    }
}
