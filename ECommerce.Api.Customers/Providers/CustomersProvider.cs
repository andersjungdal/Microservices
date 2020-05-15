using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Domain.Commands;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext dbContext;
        private readonly ILogger<CustomersProvider> logger;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IEventBus eventBus;

        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper,
            IConfigurationProvider configurationProvider, IEventBus eventBus)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
            this.eventBus = eventBus;
            //SeedData();
        }

        //private void SeedData()
        //{
        //    if (!dbContext.Customers.Any())
        //    {
        //        dbContext.Customers.Add(new Db.Customer() { Id = 1, Name = "Jessica Smith", Address = "20 Elm St." });
        //        dbContext.Customers.Add(new Db.Customer() { Id = 2, Name = "John Smith", Address = "30 Main St." });
        //        dbContext.Customers.Add(new Db.Customer() { Id = 3, Name = "William Johnson", Address = "100 10th St." });
        //        dbContext.SaveChanges();
        //    }
        //}

        public async Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                logger?.LogInformation("Querying customers");
                var customers = await dbContext.Customers.ToListAsync();
                if (customers != null && customers.Any())
                {
                    logger?.LogInformation($"{customers.Count} customer(s) found");
                    var result = mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(customers);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying customers");
                var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    logger?.LogInformation("Customer found");
                    var result = mapper.Map<Db.Customer, Models.Customer>(customer);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Db.Customer Customer, string ErrorMessage)> PostCustomerAsync([FromBody] Models.Customer customer)
        {
            try
            {


                logger?.LogInformation("Creating customer");
                var mapper = configurationProvider.CreateMapper();
                var newcustomer = mapper.Map<Db.Customer>(customer);
                if (newcustomer != null)
                {
                    dbContext.Customers.Add(newcustomer);
                    await dbContext.SaveChangesAsync();
                    logger?.LogInformation($"product created {newcustomer}");

                    var createPostCustomerCommand = new CreatePostCustomerCommand(newcustomer.Id, customer.Name, customer.Address);
                    await eventBus.SendCommand(createPostCustomerCommand);

                    return (true, newcustomer, null);
                }


                return (false, null, "Not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Db.Customer Customer, string ErrorMessage)> DeleteCustomerAsync(int id)
        {
            try
            {
                var findcustomer = dbContext.Customers.SingleOrDefault(x => x.Id == id);
                if (findcustomer == null) return (false, null, "Not updated");
                dbContext.Customers.Remove(findcustomer);
                await dbContext.SaveChangesAsync();
                logger?.LogInformation($"Deleted product {findcustomer}");
                return (true, findcustomer, null);

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}