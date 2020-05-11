using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Profiles;
using ECommerce.Api.Customers.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Products.Tests
{
    public class CustomersServiceTest
    {
        [Fact]
        public async Task GetCustomersReturnsAllCustomers()
        {
            var options = new DbContextOptionsBuilder<CustomersDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Customers.Database;Integrated Security=True")
                .Options;
            var dbContext = new CustomersDbContext(options);

            var customerProfile = new CustomerProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(customerProfile));
            var mapper = new Mapper(configuration);

            var customersProvider = new CustomersProvider(dbContext, null, mapper, configuration);

            var customer = await customersProvider.GetCustomersAsync();
            Assert.True(customer.IsSuccess);
            Assert.True(customer.Customers.Any());
            Assert.Null(customer.ErrorMessage);
        }

        [Fact]
        public async Task GetCustomerReturnsCustomerUsingValidId()
        {
            var options = new DbContextOptionsBuilder<CustomersDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Customers.Database;Integrated Security=True")
                .Options;
            var dbContext = new CustomersDbContext(options);

            var customerProfile = new CustomerProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(customerProfile));
            var mapper = new Mapper(configuration);

            var customersProvider = new CustomersProvider(dbContext, null, mapper, configuration);

            var customer = await customersProvider.GetCustomerAsync(1);
            Assert.True(customer.IsSuccess);
            Assert.NotNull(customer.Customer);
            Assert.True(customer.Customer.Id == 1);
            Assert.Null(customer.ErrorMessage);
        }

        [Fact]
        public async Task GetCustomerReturnsCustomerUsingInvalidId()
        {
            var options = new DbContextOptionsBuilder<CustomersDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Customers.Database;Integrated Security=True")
                .Options;
            var dbContext = new CustomersDbContext(options);

            var customerProfile = new CustomerProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(customerProfile));
            var mapper = new Mapper(configuration);

            var customersProvider = new CustomersProvider(dbContext, null, mapper, configuration);

            var customer = await customersProvider.GetCustomerAsync(-1);
            Assert.False(customer.IsSuccess);
            Assert.Null(customer.Customer);
            Assert.NotNull(customer.ErrorMessage);
        }
    }
}
