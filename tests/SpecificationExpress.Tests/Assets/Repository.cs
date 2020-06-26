using System.Collections.Generic;
using SpecificationExpress.Tests.Assets.Models;

namespace SpecificationExpress.Tests.Assets
{
    public class Repository
    {
        public List<Product> GetProducts()
        {
            var product = new Product {Id = 1, Name = "Mouse", Price = 3, Quantity = 1};
            return  new List<Product>()
            {
                new Product {Id = 1, Name = "Mouse", Price = 3, Quantity = 30 },
                new Product {Id = 2, Name = "Keyboard", Price = 10, Quantity = 20 },
                new Product {Id = 3, Name = "Monitor", Price = 120, Quantity = 1 },
                new Product {Id = 4, Name = "HeadSet", Price = 30, Quantity = 5 },
                new Product {Id = 5, Name = "Processor", Price = 90, Quantity = 10 },
                new Product {Id = 6, Name = "Cooler", Price = 4, Quantity = 1 },
                new Product {Id = 7, Name = "PenDrive", Price = 5, Quantity = 10 },
            };
        }
        
        public  List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client(1, "John", true, false),
                new Client(1, "Mark", true, true),
                new Client(1, "Bob", false, false),
            };
        }
    }
}