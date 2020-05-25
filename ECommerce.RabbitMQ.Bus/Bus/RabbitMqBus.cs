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
    //sealed to prevent inheritance
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        //holds handlers for all events
        private readonly Dictionary<string, List<Type>> _handlers;
        //list of event types
        private readonly List<Type> _eventTypes;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMQBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void PublishEvent<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://admin:iamadmin@localhost:5672") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //gets the types name of the generic @event
                var eventName = @event.GetType().Name;

                //create a queue with the above mentioned eventName
                channel.QueueDeclare(eventName, true, false, false, null);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = false;

                //converts the @event to a JSON string
                var message = JsonConvert.SerializeObject(@event);
                //converts the message into bytes
                var body = Encoding.UTF8.GetBytes(message);

                //publishes the body to the above declared queue, with the name of eventName
                channel.BasicPublish("", eventName, null, body);
            }
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            //another way of getting the name of the event
            var eventName = typeof(T).Name;
            //gets the type of eventhandler
            var handlerType = typeof(TH);

            //if it the list if events does not already contain that type of event, add the event type
            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            //check if the dictionary keys already exist with that event name
            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            //basic validation
            //if a handler, within that eventName(key) already exists, throw exception
            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler, of type {handlerType.Name} is already registered for '{eventName}'", nameof(handlerType));
            }

            //adds a handlertype to the list, with the already defined string key, with the value of eventName
            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://admin:iamadmin@localhost:5672"), DispatchConsumersAsync = true };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            //gets the name of T type, from where it's comming in. The method<T>
            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, true, false, false, null);

            //async consumer
            var consumer = new AsyncEventingBasicConsumer(channel);
            //delegate for the received message (+= defines a delegate)
            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.RoutingKey;
            var message = Encoding.UTF8.GetString(@event.Body);

            //kicks off the event handler
            try
            {
                //the ProccessEvent knows which handler is subscribed to this type of event
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            //check the dictionary to see if we already have the specified type of handler, based on key
            if (_handlers.ContainsKey(eventName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        //creates a new subscription event
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler == null) continue;
                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
        }
    }
}