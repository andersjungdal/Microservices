using ECommerce.Api.Orders.Domain.Commands;
using ECommerce.Api.Orders.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Domain.Command
{
    public class PostOrderCommandHandler : IRequestHandler<CreatePostOrderCommand, bool>
    {
        private readonly IEventBus eventBus;

        public PostOrderCommandHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }
        public Task<bool> Handle(CreatePostOrderCommand request, CancellationToken cancellationToken)
        {
            eventBus.PublishEvent(new PostOrderCreatedEvent(request.OrderDate, request.Total, request.Items));
            return Task.FromResult(true);
        }
    }
}
