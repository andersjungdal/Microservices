using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.RabbitMQ.Bus.Bus.Interfaces
{
    public interface IEventHandler<in TEvent> : IEventHandler
    {
        Task Handle(TEvent @event);
    }
    public interface IEventHandler
    {
    }
}
