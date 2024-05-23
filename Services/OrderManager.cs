using LunchOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchOrderingSystem.Services
{
    public class OrderManager
    {
        private readonly List<ProductionUnit> _units;
        private readonly Queue<Order> _pendingOrdr = new Queue<Order>();
        public OrderManager(List<ProductionUnit> units)
        {
            _units = units;
        }

        public void AssignOrder(Order order)
        {
            if (_units.All(u => !u.IsAvailable))
            {

                _pendingOrdr.Enqueue(order);
                const string message = "All units are busy. Order is pending";
                order.Details = message;
                Console.WriteLine(message);
                return;
            }
            var unit = _units.Where(u => u.IsAvailable && u.Products.Any(p => p.Id == order.Product.Id) && u.Products.Count(p => p.Id == order.Product.Id) >= order.Quantity).FirstOrDefault();
            if (unit == null)
            {
                const string message = "No unit is available to process the order. Order is pending";
                order.Details = message;
                Console.WriteLine(message);
                _pendingOrdr.Enqueue(order);
                return;
            }
            // remove the products with same order product Id from the unit based on the quantity likw wn qt is 2  remove 2 of them
            var delProducts = unit.Products.Where(p => p.Id == order.Product.Id).Take(order.Quantity).ToList();

            unit.IsAvailable = false;
            // compute time stamp for quntity
            order.ProcessingTime =

            order.ProcessingTime = TimeSpan.FromSeconds(order.ProcessingTime.TotalSeconds * order.Quantity);
            order.Details = $"Order for {order.Quantity} {order.Product.Name} is assigned to {unit.Name} and will be ready in {order.ProcessingTime.TotalMinutes} minutes";
            Console.WriteLine(order.Details);
            Task.Delay(order.ProcessingTime).ContinueWith(t =>
            {
                //unit.Products.Remove(order.Product);
                unit.Products.RemoveAll(p => delProducts.Contains(p));
                unit.IsAvailable = true;
                Console.WriteLine($"Order for {order.Quantity} {order.Product.Name} is ready");
                if (_pendingOrdr.Any())
                {
                    AssignOrder(_pendingOrdr.Dequeue());
                }
            });

        }
    }
}
