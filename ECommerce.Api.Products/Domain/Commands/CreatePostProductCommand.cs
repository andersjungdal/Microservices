using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Domain.Commands
{
    public class CreatePostProductCommand : PostProductCommand
    {
        public CreatePostProductCommand(string name)
        {
            Name = name;
        }
    }
}
