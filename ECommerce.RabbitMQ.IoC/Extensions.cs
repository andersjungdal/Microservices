using ECommerce.RabbitMQ.Bus.Bus;
using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using ECommerce.RabbitMQ.Bus.Events;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.RabbitMQ.IoC
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
        }

        public static void Subscribe<T, TH>(this IApplicationBuilder app) where T : Event where TH : IEventHandler<T>
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<T, TH>();
        }
    }
}
