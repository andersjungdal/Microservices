using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Domain.Commands;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IEventBus eventBus;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper, 
            IConfigurationProvider configurationProvider, IEventBus eventBus)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
            this.eventBus = eventBus;
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetAllOrdersAsync()
        {
            try
            {
                logger?.LogInformation("Querying customers");
                var orders = await dbContext.Orders
                    .Include(o => o.Items)
                    .ToListAsync();

                if (orders != null)
                {
                    logger?.LogInformation($"{orders.Count} order(s) found");
                    var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);
                    return (true, result, null);
                }
                return (false, null, "It was not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }


        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await dbContext.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(o => o.Items)
                    .ToListAsync();
                if (orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>, 
                        IEnumerable<Models.Order>>(orders);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }    
        }

        public async Task<(bool IsSuccess, Db.Order Orders, string ErrorMessage)> PostOrderAsync([FromBody] Models.Order order)
        {
            try
            {


                logger?.LogInformation("Creating order");
                var mapper = configurationProvider.CreateMapper();
                var neworder = mapper.Map<Db.Order>(order);
                if (neworder != null)
                {
                    dbContext.Orders.Add(neworder);
                    await dbContext.SaveChangesAsync();
                    logger?.LogInformation($"order created {neworder}");

                    var createPostOrderCommand = new CreatePostOrderCommand(order.OrderDate, order.Total, order.Items);
                    await eventBus.SendCommand(createPostOrderCommand);

                    return (true, neworder, null);
                }

                return (false, null, "Not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}