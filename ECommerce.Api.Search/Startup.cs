using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.Search.Db;
using ECommerce.Api.Search.Domain.EventHandlers;
using ECommerce.Api.Search.Domain.Events;
using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Services;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using ECommerce.RabbitMQ.Bus.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using MediatR;
using ECommerce.RabbitMQ.IoC;

namespace ECommerce.Api.Search
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("OrdersService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Orders"]);
            });
            services.AddHttpClient("ProductsService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Products"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
            services.AddHttpClient("CustomersService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Customers"]);
            });
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddControllers();
            services.AddDbContext<SearchesDbContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Search.Database;Integrated Security=True"));
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMq();

            services.AddTransient<PostCustomerEventHandler>();

            services.AddTransient<IEventHandler<PostCustomerCreatedEvent>, PostCustomerEventHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Subscribe<PostCustomerCreatedEvent, PostCustomerEventHandler>();
        }       
    }
}
