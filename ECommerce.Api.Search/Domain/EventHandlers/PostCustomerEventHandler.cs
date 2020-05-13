using ECommerce.Api.Search.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.EventHandlers
{
    public class PostCustomerEventHandler : IEventHandler<PostCustomerCreatedEvent>
    {
        public Task Handle(PostCustomerCreatedEvent @event)
        {
            var @new = @event;
            return Task.CompletedTask;
        }
    }
}
