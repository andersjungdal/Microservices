using ECommerce.RabbitMQ.Bus.Commands;
using ECommerce.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.RabbitMQ.Bus.Bus.Interfaces
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void PublishEvent<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>; 
    }
}
