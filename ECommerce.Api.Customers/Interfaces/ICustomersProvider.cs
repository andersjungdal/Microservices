using ECommerce.Api.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface ICustomersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
        Task<(bool IsSuccess, Db.Customer Customer, string ErrorMessage)> PostCustomerAsync([FromBody] Customer customer);
        Task<(bool IsSuccess, Db.Customer Customer, string ErrorMessage)> DeleteCustomerAsync(int id);

    }
}
