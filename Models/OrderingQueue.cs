using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchOrderingSystem.Models
{
    public enum Status
    {
        Waiting,
        Ibnprogtress,
        Done,
    }
    public class OrderingQueue
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int OrderId { set; get; }
        public int ProductionId { set; get; }
        public string ProductionName { set; get;}
        public Status status { set; get; }
    }
}
