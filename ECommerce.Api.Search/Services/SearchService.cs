using ECommerce.Api.Search.Db;
using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService ordersService;
        private readonly IProductsService productsService;
        private readonly ICustomersService customersService;
        private readonly SearchesDbContext searchesDbContext;
        private readonly ILogger logger;

        public SearchService(IOrdersService ordersService, IProductsService productsService, ICustomersService customersService, SearchesDbContext searchesDbContext, ILogger logger )
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
            this.customersService = customersService;
            this.searchesDbContext = searchesDbContext;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetAllSearchesAsync()
        {
            try
            {
                logger?.LogInformation("Querying customers");
                var searches = await searchesDbContext.Customers.Include(p => p.Orders.Select(n => n.Items)).ToListAsync();
                if (searches != null && searches.Any())
                {
                    logger?.LogInformation($"{searches.Count} customer(s) found");
                    //var result = mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(customers);
                    return (true, searches, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var ordersResult = await ordersService.GetOrdersAsync(customerId);
            var productsResult = await productsService.GetProductsAsync();
            var customersResult = await customersService.GetCustomersAsync(customerId);
            
            if (ordersResult.IsSuccess)
            {              
                    foreach (var order in ordersResult.Orders)
                    {
                        foreach (var item in order.Items)
                        {
                            item.ProductName = productsResult.IsSuccess ?
                                productsResult.Products.FirstOrDefault(x => x.Id == item.ProductId)?.Name :
                                "Product information is not available";
                        }
                    }

                var result = new
                {
                    Customer = ordersResult.IsSuccess ?
                        customersResult.Customer :
                            new { Name = "Customer information is not available" },
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
