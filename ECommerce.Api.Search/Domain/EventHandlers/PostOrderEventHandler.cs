using ECommerce.Api.Search.Db;
using ECommerce.Api.Search.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.EventHandlers
{
    public class PostOrderEventHandler : IEventHandler<PostOrderCreatedEvent>
    {
        private readonly SearchesDbContext searchesDbContext;

        public PostOrderEventHandler(SearchesDbContext searchesDbContext)
        {
            this.searchesDbContext = searchesDbContext;
        }
        public Task Handle(PostOrderCreatedEvent @event)
        {
            searchesDbContext.Orders.Add(new Order
            {
                OrderDate = @event.OrderDate,
                Total = @event.Total,
                Items = @event.Items
            });
            searchesDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
