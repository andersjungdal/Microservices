using ECommerce.Api.Orders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetAllOrdersAsync();
        Task<(bool IsSuccess, Db.Order Orders, string ErrorMessage)> PostOrderAsync([FromBody] Order order);
    }
}
