using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchOrderingSystem.Models
{
    public class ProductionUnit
    {
        public ProductionUnit() { }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Type { set; get; }
        public bool IsAvailable { set; get; }

    }
}
