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
    public class HttpClientCustomersService : IHttpClientCustomersService
    {
        private readonly HttpClient httpClient;

        public HttpClientCustomersService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<(bool IsSuccess, string ErrorMessage)> PostCustomerAsync(Customer customer)
        {
            try
            {
                //Serialize et objekt til JSON string
                var httpContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
                //Finder CustomerController base address Post metode
                var response = await httpClient.PostAsync("customers", httpContent);
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
