using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Profiles;
using ECommerce.Api.Orders.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Orders.Tests
{
    public class OrdersServiceTest
    {
        [Fact]
        public async Task GetOrdersReturnsAllOrders()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Orders.Database;Integrated Security=True")
                .Options;
            var dbContext = new OrdersDbContext(options);

            var orderProfile = new OrderProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(orderProfile));
            var mapper = new Mapper(configuration);

            var ordersProvider = new OrdersProvider(dbContext, null, mapper, configuration);

            var order = await ordersProvider.GetAllOrdersAsync();
            Assert.True(order.IsSuccess);
            Assert.True(order.Orders.Any());
            Assert.Null(order.ErrorMessage);
        }
    }
}
