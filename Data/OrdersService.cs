using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForDiplom.Context;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Data
{
    public class OrdersService : IOrderData
    {
        static List<Order> data;

        private readonly DataContext _context;
        public OrdersService(DataContext context)
        {
            this._context = context;
            
            /*var order1 = new Order( "sdfsf");
            var order2 = new Order( "aaaaa");
            db.Orders.Add(order1);
            db.Orders.Add(order2);
            db.SaveChanges();*/

            data = _context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrders()
        {
             return data;
        }

        public void AddOrder(string name)
        {
             Order order = new Order(name);

             _context.Orders.Add(order);
             _context.SaveChanges();            
        }
    }
}
