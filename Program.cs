using LunchOrderingSystem.Models;
using LunchOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunchOrderingSystem
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///[STAThread]
        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            var units = new List<ProductionUnit>{
                new ProductionUnit{Id=1, Name="Unit 1", IsAvailable = true, Products = new List<Product>{
                    new Product { Id = 1, Name = "Product 1", Description = "Product 1 Description", Price = 100 },
                    new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Price = 200 },
                    new Product { Id = 3, Name = "Product 3", Description = "Product 3 Description", Price = 300 },
                    new Product { Id = 5, Name = "Product 5", Description = "Product 5 Description", Price = 500 },
                    new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Price = 200 },
                } },
                new ProductionUnit{Id=2, Name="Unit 2"},
                new ProductionUnit{Id=3, Name="Unit 3", IsAvailable = true, Products = new List<Product>{
                    new Product { Id = 1, Name = "Product 1", Description = "Product 1 Description", Price = 100 },
                    new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Price = 200 },
                    new Product { Id = 3, Name = "Product 3", Description = "Product 3 Description", Price = 300 },
                    new Product { Id = 4, Name = "Product 4", Description = "Product 4 Description", Price = 400 },
                    new Product { Id = 5, Name = "Product 5", Description = "Product 5 Description", Price = 500 },
                    new Product { Id = 6, Name = "Product 6", Description = "Product 6 Description", Price = 600 },
                    new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Price = 200 },
                    new Product { Id = 3, Name = "Product 3", Description = "Product 3 Description", Price = 300 },
                } },
                new ProductionUnit{Id=4, Name="Unit 4" }
            };


            var manager = new OrderManager(units);

            manager.AssignOrder(new Order
            {
                Id = 1,
                Product = new Product { Id = 1, Name = "Product 1", Description = "Product 1 Description", Price = 100 },
                Quantity = 2,
                ProcessingTime = TimeSpan.FromMinutes(10)
            });
            manager.AssignOrder(new Order
            {
                Id = 2,
                Product = new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Price = 200 },
                Quantity = 1,
                ProcessingTime = TimeSpan.FromMinutes(5)
            });
            manager.AssignOrder(new Order
            {
                Id = 3,
                Product = new Product { Id = 3, Name = "Product 3", Description = "Product 3 Description", Price = 300 },
                Quantity = 3,
                ProcessingTime = TimeSpan.FromMinutes(15)
            });
            Console.ReadLine();


        }
    }
}
