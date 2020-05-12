﻿using ECommerce.RabbitMQ.Bus.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Domain.Commands
{
    public abstract class PostCustomerCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
