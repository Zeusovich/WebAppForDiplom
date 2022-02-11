using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Interfaces
{
    public interface IOrderData
    {
         IEnumerable<Order> GetOrders();

        void AddOrder(string name);
    }
}
