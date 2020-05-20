using ECommerce.Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Client.Interfaces
{
    public interface IHttpClientOrdersService
    {
        public Task<(bool IsSuccess, string ErrorMessage)> PostOrderAsync(Order order);
        public Task<(bool IsSuccess, IEnumerable<Order> product, string ErrorMessage)> GetAllOrdersAsync();
    }
}
