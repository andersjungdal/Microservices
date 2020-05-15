using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
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

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
            //SeedData();
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

        //private void SeedData()
        //{
        //    if (!dbContext.Orders.Any())
        //    {
        //        dbContext.Orders.Add(new Order()
        //        {
        //            Id = 1,
        //            CustomerId = 1,
        //            OrderDate = DateTime.Now,
        //            Items = new List<OrderItem>()
        //            {
        //                new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
        //            },
        //            Total = 100
        //        });
        //        dbContext.Orders.Add(new Order()
        //        {
        //            Id = 2,
        //            CustomerId = 1,
        //            OrderDate = DateTime.Now.AddDays(-1),
        //            Items = new List<OrderItem>()
        //            {
        //                new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
        //            },
        //            Total = 100
        //        });
        //        dbContext.Orders.Add(new Order()
        //        {
        //            Id = 3,
        //            CustomerId = 2,
        //            OrderDate = DateTime.Now,
        //            Items = new List<OrderItem>()
        //            {
        //                new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
        //                new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
        //            },
        //            Total = 100
        //        });
        //        dbContext.SaveChanges();
        //    }
        //}

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

                    //var createPostCustomerCommand = new CreatePostCustomerCommand(newcustomer.Id, customer.Name, customer.Address);
                    //await eventBus.SendCommand(createPostCustomerCommand);

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