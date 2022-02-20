using Microsoft.AspNetCore.Identity;
using System;
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
            data = _context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrders()
        {
            _context.SaveChanges(); // Посмотреть
             return data;
        }

        public List<Order> GetValues()
        {
            var values = _context.Orders.Where(x => x.Status == "Прошло оценку клиентом+Прошло оценку начальником").ToList();
            return values;
        }


        public void AddOrder(Order order)
        {
             _context.Orders.Add(order);
             _context.SaveChanges();            
        }

        public void AddWorkerName(int id, string workerName)
        {
            var orders = _context.Orders.Where(x => x.Id == id);
            foreach(var order in orders)
            if (order != null)
            {
                order.Status = "В ожидании";
                order.WorkerName = workerName;
                _context.Orders.Update(order);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetOrdersForWorker(string userName)
        {
            var ordersForWorker = _context.Orders.Where(x => x.WorkerName == userName&&
            ((x.Status=="В ожидании")||(x.Status =="В процессе"))).ToList();
            
            return ordersForWorker;
        }

        public void TakeOrder(int id)
        {
            var orders = _context.Orders.Where(x => x.Id == id);
            foreach (var order in orders)
                if (order != null)
                {
                    order.Status = "В процессе";
                    order.BeginOfWork = DateTime.Now;
                    _context.Orders.Update(order);
                }
            _context.SaveChanges();
        }

        public void SendReadyOrder(int id)
        {
            var orders = _context.Orders.Where(x => x.Id == id);
            foreach (var order in orders)
                if (order != null)
                {
                    order.Status = "Готово";
                    order.EndOfWork = DateTime.Now;
                    _context.Orders.Update(order);
                }
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetReadyOrders(string userName)
        {
            var readyOrders = _context.Orders.Where(x => x.WorkerName == userName && x.Status == "Готово").ToList();

            return readyOrders;
        }

        public IEnumerable<Order> GetReadyOrders()
        {
            var readyOrders = _context.Orders.Where(x => x.Status == "Готово" || x.Status == "Прошло оценку клиентом").ToList();

            return readyOrders;
        }


        public IEnumerable<Order> GetOrdersWithoutWorker()
        {
            var readyOrders = _context.Orders.Where(x => x.WorkerName == null).ToList();

            return readyOrders;
        }

        public void BossRate(int id, int valueBeginOfWork, int valueEndOfWork)
        {
            var orders = _context.Orders.Where(x => x.Id == id);
            foreach (var order in orders)
            {
                if (order != null && order.Status == "Готово")
                {
                    order.Status = "Прошло оценку начальником";
                    order.ValueBeginOfWork = valueBeginOfWork;
                    order.ValueEndOfWork = valueEndOfWork;
                    _context.Orders.Update(order);
                }
                if (order != null && order.Status == "Прошло оценку клиентом")
                {
                    order.Status = order.Status + "+" + "Прошло оценку начальником";
                    order.ValueBeginOfWork = valueBeginOfWork;
                    order.ValueEndOfWork = valueEndOfWork;
                    _context.Orders.Update(order);
                }
            }
            _context.SaveChanges();
        }

        public void Feedback(int id, int feedback, int recommend)
        {
            var orders = _context.Orders.Where(x => x.Id == id);
            foreach (var order in orders)
            {
                if (order != null && order.Status == "Готово")
                {
                    order.Status = "Прошло оценку клиентом";
                    order.Feedback = feedback;
                    order.Recommend = recommend;
                    _context.Orders.Update(order);
                }
                if (order != null && order.Status == "Прошло оценку начальником")
                {
                    order.Status = "Прошло оценку клиентом" + "+" + order.Status;
                    order.Feedback = feedback;
                    order.Recommend = recommend;
                    _context.Orders.Update(order);
                }
            }
            _context.SaveChanges();
        }        
    }
}
