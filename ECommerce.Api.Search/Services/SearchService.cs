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
        private readonly SearchesDbContext searchesDbContext;
        private readonly IMapper mapper;

        public SearchService(SearchesDbContext searchesDbContext, IMapper mapper)
        {
            this.searchesDbContext = searchesDbContext;
            this.mapper = mapper;
        }


        public async Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetSearchesAsync(int id)
        {
            try
            {
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
