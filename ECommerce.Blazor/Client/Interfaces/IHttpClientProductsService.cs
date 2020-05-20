using ECommerce.Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Client.Interfaces
{
    public interface IHttpClientProductsService
    {
        public Task<(bool IsSuccess, string ErrorMessage)> PostProductAsync(Product product);
        public Task<(bool IsSuccess, IEnumerable<Product> product, string ErrorMessage)> GetAllProductsAsync();
    }
}
