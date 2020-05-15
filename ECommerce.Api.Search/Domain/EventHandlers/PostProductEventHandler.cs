using ECommerce.Api.Search.Db;
using ECommerce.Api.Search.Domain.Events;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Domain.EventHandlers
{
    public class PostProductEventHandler : IEventHandler<PostProductCreatedEvent>
    {
        private readonly SearchesDbContext searchesDbContext;

        public PostProductEventHandler(SearchesDbContext searchesDbContext)
        {
            this.searchesDbContext = searchesDbContext;
        }

        public Task Handle(PostProductCreatedEvent @event)
        {
            searchesDbContext.Products.Add(new Product
            {
                Name = @event.Name
            });
            searchesDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
