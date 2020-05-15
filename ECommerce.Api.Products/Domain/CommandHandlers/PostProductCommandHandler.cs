using ECommerce.Api.Products.Domain.Commands;
using ECommerce.Api.Products.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Domain.CommandHandlers
{
    public class PostProductCommandHandler : IRequestHandler<CreatePostProductCommand, bool>
    {
        private readonly IEventBus eventBus;

        public PostProductCommandHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }
        public Task<bool> Handle(CreatePostProductCommand request, CancellationToken cancellationToken)
        {
            eventBus.PublishEvent(new PostProductCreatedEvent(request.Id, request.Name, request.Price, request.Inventory));
            return Task.FromResult(true);
        }
    }
}
