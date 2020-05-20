using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using ECommerce.Blazor.Client.Services;

namespace ECommerce.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.AddSingleton(new HttpClient());

            builder.Services.AddSingleton<HttpClientProductsService>();

            builder.Services.AddSingleton<HttpClientCustomersService>();

            await builder.Build().RunAsync();

        }
    }
}
