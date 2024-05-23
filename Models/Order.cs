using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchOrderingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string ProductName { get; set; }
        public TimeSpan ProcessingTime { get; set; }
         public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
