using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Profiles
{
    public class SearchProfile : AutoMapper.Profile
    {
        public SearchProfile()
        {
            CreateMap<Db.Customer, Models.Customer>()
                .ReverseMap();
            CreateMap<Db.Order, Models.Order>()
                .ReverseMap();
            CreateMap<Db.OrderItem, Models.OrderItem>()
                .ReverseMap();
            CreateMap<Db.Product, Models.Product>()
                .ReverseMap();
        }
    }
}
