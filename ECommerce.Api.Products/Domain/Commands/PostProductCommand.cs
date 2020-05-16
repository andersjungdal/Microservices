using ECommerce.RabbitMQ.Bus.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Domain.Commands
{
    public abstract class PostProductCommand : Command
    {
        public string Name { get; set; }
    }
}
