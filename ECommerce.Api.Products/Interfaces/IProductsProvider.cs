using ECommerce.Api.Products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Interfaces
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id);
        Task<(bool IsSuccess, Db.Product product, string ErrorMessage)> PostProductAsync([FromBody] Product product);
        Task<(bool IsSuccess, Db.Product product, string ErrorMessage)> DeleteProductAsync(int id);
    }
}