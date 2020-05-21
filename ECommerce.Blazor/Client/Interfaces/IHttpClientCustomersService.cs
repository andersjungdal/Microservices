using ECommerce.Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Client.Interfaces
{
    public interface IHttpClientCustomersService
    {
        public Task<(bool IsSuccess, string ErrorMessage)> PostCustomerAsync(Customer customer);
    }
}
