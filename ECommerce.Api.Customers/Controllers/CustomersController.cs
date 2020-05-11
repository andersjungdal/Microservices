using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Models.Customer customer)
        {
            var newcustomer = await customersProvider.PostCustomerAsync(customer);
            if (newcustomer.IsSuccess)
            {
                return Ok(newcustomer.customer);
            }
            return NotFound(newcustomer.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var customer = await customersProvider.DeleteCustomerAsync(id);
            if (customer.IsSuccess)
            {
                return Ok();
            }
            return NotFound(customer.ErrorMessage);
        }

    }
}