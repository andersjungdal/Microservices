using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class ProductsService
    {
        static HttpClient client;

        static ProductsService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:5000");
            

        }

        public static async Task<List<Product>> GetProductsAsync()
        {
            var productsRaw = await client.GetStringAsync("/products");

            var serializer = new JsonSerializer();
            using (var tReader = new StringReader(productsRaw))
            {
                using (var jReader = new JsonTextReader(tReader))
                {
                    var products = serializer.Deserialize<List<Product>>(
                        jReader);

                    return products;
                }
            }
        }
        //public static async Task<List<Product>> GetProductsAsync()
        //{
        //    try
        //    {
        //        var client = httpClientFactory.CreateClient("ProductsService");
        //        var response = await client.GetAsync("api/products");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        //            var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
        //            return (true, result, null);
        //        }
        //        return (false, null, response.ReasonPhrase);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger?.LogError(ex.ToString());
        //        return (false, null, ex.Message);
        //    }
        //}
    }
}
