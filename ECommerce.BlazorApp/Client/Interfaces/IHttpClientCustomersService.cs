using ECommerce.BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BlazorApp.Client.Interfaces
{
    public interface IHttpClientCustomersService
    {
        public Task<(bool IsSuccess, string ErrorMessage)> PostCustomerAsync(Customer customer);
    }
}
