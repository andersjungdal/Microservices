using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Domain.Command;
using ECommerce.Api.Orders.Domain.Commands;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Providers;
using ECommerce.RabbitMQ.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Api.Orders
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
            services.AddDbContext<OrdersDbContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Orders.Database;Integrated Security=True"));


            services.AddScoped<IOrdersProvider, OrdersProvider>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IRequestHandler<CreatePostOrderCommand, bool>, PostOrderCommandHandler>();
            services.AddRabbitMq();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
