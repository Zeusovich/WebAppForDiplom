using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Interfaces
{
    public interface IOrderData
    {
        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrdersWithoutWorker();
        void AddOrder(Order order);
        //List<string> GetWorkers();

        void AddWorkerName(int id,string workerName);

        IEnumerable<Order> GetOrdersForWorker(string userName);

        IEnumerable<Order> GetReadyOrders(string userName);

        IEnumerable<Order> GetReadyOrders();

        List<Order> GetValues();

        void TakeOrder(int id);

        void SendReadyOrder(int id);

        void BossRate(int id,int valueBeginOfWork,int valueEndOfWork);

        void Feedback(int id, int feedback, int recommend);
    }
}
