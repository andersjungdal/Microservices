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
            CreateMap<Db.Customer, Models.Customer>();
            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.OrderItem>();
            CreateMap<Db.Product, Models.Product>();
        }
    }
}
