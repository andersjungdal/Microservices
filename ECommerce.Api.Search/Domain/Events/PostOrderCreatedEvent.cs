using ECommerce.Api.Search.Db;
using ECommerce.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.Events
{
    public class PostOrderCreatedEvent : Event
    {
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; }

        public PostOrderCreatedEvent(DateTime orderdate, decimal total, List<OrderItem> items)
        {
            OrderDate = orderdate;
            Total = total;
            Items = items;

        }
    }
}
