using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSearchesAsync(int id)
        {
            var result = await searchService.GetSearchesAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSearchesAsync()
        {
            var result = await searchService.GetAllSearchesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }


        //[HttpPost]
        //public async Task<IActionResult> SearchAsync(SearchTerm term)
        //{
        //    var result = await searchService.SearchAsync(term.CustomerId);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result.SearchResults);
        //    }
        //    return NotFound();

        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchAsync(int id)
        {
            var result = await searchService.DeleteSearchAsync(id);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.ErrorMessage);
        }
    }
}
