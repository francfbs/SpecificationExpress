using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationExpress.Tests.Assets.Models
{
    public class Order
    {
        public Order(int id, DateTime date, int clientId, List<OrderItem> items)
        {
            Id = id;
            Date = date;
            Items = items;
            ClientId = clientId;
            TotalPrice = items.Sum(i => i.Price);
        }

        public int Id { get; }
        public DateTime Date { get; }
        public List<OrderItem> Items { get; }
        public int ClientId { get; }
        public double TotalPrice { get; }
    }
    
    public class OrderItem
    {
        public OrderItem(int id, string description, double quantity, double price)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; }
        public string Description { get; }
        public double Quantity { get; }
        public double Price { get; }
    }
}