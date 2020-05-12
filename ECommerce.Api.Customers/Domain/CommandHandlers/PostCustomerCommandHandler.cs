using ECommerce.Api.Customers.Domain.Commands;
using ECommerce.Api.Customers.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Domain.CommandHandlers
{
    public class PostCustomerCommandHandler : IRequestHandler<CreatePostCustomerCommand, bool>
    {
        private readonly IEventBus eventBus;

        public PostCustomerCommandHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public Task<bool> Handle(CreatePostCustomerCommand request, CancellationToken cancellationToken)
        {
            eventBus.PublishEvent(new PostCustomerCreatedEvent(request.Id, request.Name, request.Address));
            return Task.FromResult(true);
        }
    }
}
