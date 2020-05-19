using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using ECommerce.Blazor.Shared.Models;
using System.Text;

namespace ECommerce.Blazor.Client.Services
{
    public class HttpClientConnection
    {
        private readonly HttpClient httpClientFactory;

        public HttpClientConnection(HttpClient httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<(bool IsSuccess, string ErrorMessage)> PostProductAsync(Product product)
        {
            try
            {
                var httpContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
                var response = await httpClientFactory.PostAsync("https://localhost:5004/api/products", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    //var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    //var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
                    return (true, null);
                }
                return (false, response.ReasonPhrase);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
