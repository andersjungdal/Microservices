using ECommerce.BlazorApp.Client.Interfaces;
using ECommerce.BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.BlazorApp.Client.Services
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
                var response = await httpClient.PostAsync("products", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
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
