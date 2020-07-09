using System.Collections.Generic;
using System.Linq;
using SpecificationExpress.Tests.Assets.Models;

namespace SpecificationExpress.Tests.Assets
{
    public class Repository
    {
        private readonly List<Product> _productList = new List<Product>()
        {
            new Product {Id = 1, Name = "Mouse", Price = 3, Quantity = 30},
            new Product {Id = 2, Name = "Keyboard", Price = 10, Quantity = 20},
            new Product {Id = 3, Name = "Monitor", Price = 120, Quantity = 1},
            new Product {Id = 4, Name = "HeadSet", Price = 30, Quantity = 5},
            new Product {Id = 5, Name = "Processor", Price = 90, Quantity = 10},
            new Product {Id = 6, Name = "Cooler", Price = 4, Quantity = 1},
            new Product {Id = 7, Name = "PenDrive", Price = 5, Quantity = 10},
        };
        public List<Product> GetProducts()
        {
            return _productList;
        }
        
        public Product GetProductById(int id)
        {
            return _productList.FirstOrDefault(p => p.Id == id);
        }
        
        public  List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client(1, "John", true, false),
                new Client(2, "Mark", true, true),
                new Client(3, "Bob", false, false),
            };
        }
    }
}