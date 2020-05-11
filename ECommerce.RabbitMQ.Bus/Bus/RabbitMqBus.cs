using ECommerce.RabbitMQ.Bus.Bus.Interfaces;
using ECommerce.RabbitMQ.Bus.Commands;
using ECommerce.RabbitMQ.Bus.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.RabbitMQ.Bus.Bus
{
    public sealed class RabbitMqBus : IEventBus
    {
        private readonly List<Type> eventTypes;
        private readonly Dictionary<string, List<Type>> handlers;
        private readonly IMediator mediator;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public RabbitMqBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            this.mediator = mediator;
            this.serviceScopeFactory = serviceScopeFactory;
            handlers = new Dictionary<string, List<Type>>();
            eventTypes = new List<Type>();
        }    

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public void PublishEvent<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            var eventName = @event.GetType().Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            channel.ExchangeDeclare(eventName, ExchangeType.Fanout);
            channel.BasicPublish(eventName, "", null, body);
        }

        public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!eventTypes.Contains(typeof(T))) eventTypes.Add(typeof(T));
            if(!handlers.ContainsKey(eventName)) handlers.Add(eventName, new List<Type>());
            if (handlers[eventName].Any(x => x.GetType() == handlerType))
                throw new ArgumentException($"Handler Type {handlerType.Name} is already registered for {eventName}",
                    nameof(handlerType));

            handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }
        
        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var Connection = factory.CreateConnection();
            var channel = Connection.CreateModel();
            var eventName = typeof(T).Name;
            var queueName = channel.QueueDeclare(eventName + "-" + Guid.NewGuid().ToString(), false, false, true, null).QueueName;

            channel.ExchangeDeclare(eventName, ExchangeType.Fanout);
            channel.QueueBind(queueName, eventName, "");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queueName, true, consumer);
        }
        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.Exchange;
            var message = Encoding.UTF8.GetString(@event.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if(handlers.ContainsKey(eventName))
                using(var scope = serviceScopeFactory.CreateScope())
                {
                    var subscriptions = handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler == null) continue;
                        var eventType = eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new[] { @event });
                    }
                }
        }
    }
    
}
