using ECommerce.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.Events
{
    public class PostCustomerCreatedEvent : Event
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public PostCustomerCreatedEvent(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
