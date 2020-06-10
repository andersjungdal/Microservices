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
    public class CustomersService
    {
        static HttpClient client;

        static CustomersService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:5004");
        }

        public static async Task<List<Customer>> GetCustomersAsync()
        {
            var customersRaw = await client.GetStringAsync("api/customers");

            var serializer = new JsonSerializer();
            using (var tReader = new StringReader(customersRaw))
            {
                using (var jReader = new JsonTextReader(tReader))
                {
                    var customers = serializer.Deserialize<List<Customer>>(
                        jReader);

                    return customers;
                }
            }
        }
    }
}
