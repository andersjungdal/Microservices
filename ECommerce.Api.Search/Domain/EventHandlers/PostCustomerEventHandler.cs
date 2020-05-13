using ECommerce.Api.Search.Db;
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
        private readonly SearchesDbContext searchesDbContext;

        public PostCustomerEventHandler(SearchesDbContext searchesDbContext)
        {
            this.searchesDbContext = searchesDbContext;
        }
        public Task Handle(PostCustomerCreatedEvent @event)
        {
            searchesDbContext.Customers.Add(new Customer
            {
                Address = @event.Address,
                Name = @event.Name,
                CustomerId = @event.Id                
            });
            searchesDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
