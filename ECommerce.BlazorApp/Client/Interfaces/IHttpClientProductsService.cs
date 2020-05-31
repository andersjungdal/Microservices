using ECommerce.BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BlazorApp.Client.Interfaces
{
    interface IHttpClientProductsService
    {
        public Task<(bool IsSuccess, string ErrorMessage)> PostProductAsync(Product product);
    }
}
