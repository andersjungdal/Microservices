using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using ECommerce.Blazor.Shared.Models;
using System.Text;
using ECommerce.Blazor.Client.Interfaces;

namespace ECommerce.Blazor.Client.Services
{
    public class HttpClientProductsService : IHttpClientProductsService
    {
        private readonly HttpClient httpClient;

        public HttpClientProductsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        

        public async Task<(bool IsSuccess, string ErrorMessage)> PostProductAsync(Product product)
        {
            try
            {
                var httpContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:5004/api/products", httpContent);
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
