using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Domain.Commands
{
    public class CreatePostCustomerCommand : PostCustomerCommand
    {
        public CreatePostCustomerCommand(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
