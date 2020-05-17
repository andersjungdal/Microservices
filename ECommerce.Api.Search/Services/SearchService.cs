using AutoMapper;
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
        //private readonly IOrdersService ordersService;
        //private readonly IProductsService productsService;
        //private readonly ICustomersService customersService;
        private readonly SearchesDbContext searchesDbContext;
        private readonly IMapper mapper;

        public SearchService(/*IOrdersService ordersService, IProductsService productsService, ICustomersService customersService,*/ SearchesDbContext searchesDbContext, IMapper mapper)
        {
            //this.ordersService = ordersService;
            //this.productsService = productsService;
            //this.customersService = customersService;
            this.searchesDbContext = searchesDbContext;
            this.mapper = mapper;
        }


        public async Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetSearchesAsync(int id)
        {
            try
            {
                //var searches = await searchesDbContext.Customers.FirstOrDefaultAsync(l => l.Id == id);

                var searches = await searchesDbContext.Customers
                    .Include(o => o.Orders)
                    .ThenInclude(c => c.Items)
                    .FirstOrDefaultAsync(x => x.Id == id);
                
                if (searches != null)
                {

                    var result = mapper.Map<Db.Customer, Models.Customer>(searches);
                    return (true, result, null);
                }
                return (false, null, "It was not found");
            }
            catch (Exception ex)
            {
                
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetAllSearchesAsync()
        {
            try
            {
                //var searches = await searchesDbContext.Customers.FirstOrDefaultAsync(l => l.Id == id);

                var searches = await searchesDbContext.Customers
                    .Include(o => o.Orders)
                    .ThenInclude(c => c.Items)
                    .ToListAsync();

                if (searches != null)
                {
                    var result = mapper.Map<IEnumerable<Models.Customer>>(searches);
                    return (true, result, null);
                }
                return (false, null, "It was not found");
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }
        }

        //public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        //{
        //    var ordersResult = await ordersService.GetOrdersAsync(customerId);
        //    var productsResult = await productsService.GetProductsAsync();
        //    var customersResult = await customersService.GetCustomersAsync(customerId);
            
        //    if (ordersResult.IsSuccess)
        //    {              
        //            foreach (var order in ordersResult.Orders)
        //            {
        //                foreach (var item in order.Items)
        //                {
        //                    item.ProductName = productsResult.IsSuccess ?
        //                        productsResult.Products.FirstOrDefault(x => x.Id == item.ProductId)?.Name :
        //                        "Product information is not available";
        //                }
        //            }

        //        var result = new
        //        {
        //            Customer = ordersResult.IsSuccess ?
        //                customersResult.Customer :
        //                    new { Name = "Customer information is not available" },
        //            Orders = ordersResult.Orders
        //        };
        //        return (true, result);
        //    }
        //    return (false, null);
        //}

        public async Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> DeleteSearchAsync(int id)
        {
            try 
            { 
                var searches = await searchesDbContext.Customers
                        .Include(o => o.Orders)
                        .ThenInclude(c => c.Items)
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (searches == null) return (false, null, "Not updated");
                searchesDbContext.Customers.Remove(searches);
                await searchesDbContext.SaveChangesAsync();
                return (true, searches, null);              
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }

}
    }
}
