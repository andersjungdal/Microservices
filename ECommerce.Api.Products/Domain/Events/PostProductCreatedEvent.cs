using ECommerce.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Domain.Events
{
    public class PostProductCreatedEvent : Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public PostProductCreatedEvent(int id, string name, decimal price, int inventory)
        {
            Id = id;
            Name = name;
            Price = price;
            Inventory = inventory;
        }
    }
}
