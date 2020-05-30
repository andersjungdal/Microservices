using ECommerce.Blazor.Client.Interfaces;
using ECommerce.Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Client.Services
{
    public class HttpClientOrdersService : IHttpClientOrdersService
    {
        private readonly HttpClient httpClient;

        public HttpClientOrdersService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        

        public async Task<(bool IsSuccess, string ErrorMessage)> PostOrderAsync(Order order)
        {
            try
            {
                var httpContent = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:5000/orders", httpContent);
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
