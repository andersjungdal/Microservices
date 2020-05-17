using AutoMapper;
using ECommerce.Api.Search.Db;
using ECommerce.Api.Search.Profiles;
using ECommerce.Api.Search.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Search.Tests
{
    public class SearchServiceTest
    {
        [Fact]
        public async Task GetSearchesReturnsAllSearches()
        {
            var options = new DbContextOptionsBuilder<SearchesDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Search.Database;Integrated Security=True")
                .Options;
            var dbContext = new SearchesDbContext(options);

            var searchProfile = new SearchProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(searchProfile));
            var mapper = new Mapper(configuration);

            var searchService = new SearchService(dbContext, mapper);

            var search = await searchService.GetAllSearchesAsync();
            Assert.True(search.IsSuccess);
            Assert.Null(search.ErrorMessage);
        }
    }
}
