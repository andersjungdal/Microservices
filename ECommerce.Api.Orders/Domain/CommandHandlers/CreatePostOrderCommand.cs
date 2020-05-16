using ECommerce.Api.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Domain.Commands
{
    public class CreatePostOrderCommand : PostOrderCommand
    {
        public CreatePostOrderCommand(DateTime orderdate, decimal total, List<OrderItem> items)
        {
            OrderDate = orderdate;
            Total = total;
            Items = items;
        }
    }
}
