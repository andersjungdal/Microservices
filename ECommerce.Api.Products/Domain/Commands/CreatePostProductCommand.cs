using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Domain.Commands
{
    public class CreatePostProductCommand : PostProductCommand
    {
        public CreatePostProductCommand(int id, string name, decimal price, int inventory)
        {
            Id = id;
            Name = name;
            Price = price;
            Inventory = inventory;         
        }
    }
}
