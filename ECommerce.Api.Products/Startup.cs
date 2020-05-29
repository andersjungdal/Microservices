using AutoMapper;
using ECommerce.Api.Products.Db;

using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Providers;
using ECommerce.RabbitMQ.IoC;
using MediatR;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerce.Api.Products.Domain.CommandHandlers;
using ECommerce.Api.Products.Domain.Commands;

namespace ECommerce.Api.Products
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
            services.AddApplicationInsightsTelemetry("8ea3060a-8e0e-4368-830a-48b2d4116c97");
            services.AddControllers();
            services.AddScoped<IProductsProvider, ProductsProvider>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Products.Database;Integrated Security=True"));

            services.AddMediatR(typeof(Startup));
            services.AddTransient<IRequestHandler<CreatePostProductCommand, bool>, PostProductCommandHandler>();
            services.AddRabbitMq();

            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
        
    }
}