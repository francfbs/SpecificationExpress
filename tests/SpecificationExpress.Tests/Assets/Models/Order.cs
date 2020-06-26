using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationExpress.Tests.Assets.Models
{
    public class Order
    {
        public Order(int id, DateTime date, int clientId, List<OrderItem> itens)
        {
            Id = id;
            Date = date;
            Itens = itens;
            ClientId = clientId;
            TotalPrice = itens.Sum(i => i.Price);
        }

        public int Id { get; }
        public DateTime Date { get; }
        public List<OrderItem> Itens { get; }
        public int ClientId { get; }
        public double TotalPrice { get; }
    }
    
    public class OrderItem
    {
        public OrderItem(int id, double quantity, double price)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; }
        public double Quantity { get; }
        public double Price { get; }
    }
}