using ECommerce.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.Events
{
    public class PostProductCreatedEvent : Event
    {
        public string Name { get; set; }
        public PostProductCreatedEvent(string name)
        {
            Name = name;
        }
    }
}
