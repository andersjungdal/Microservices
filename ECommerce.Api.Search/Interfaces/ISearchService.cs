using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetSearchesAsync(int id);
        Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> GetAllSearchesAsync();

        Task<(bool IsSuccess, dynamic SearchResults, string ErrorMessage)> DeleteSearchAsync(int id);
    }
}
