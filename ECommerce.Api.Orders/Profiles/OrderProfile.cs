namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Db.Order, Models.Order>()
                .ReverseMap();
            CreateMap<Db.OrderItem, Models.OrderItem>()
                .ReverseMap();
            //CreateMap<Models.Order, Db.Order>();
            //CreateMap<Models.OrderItem, Db.OrderItem>();
        }
    }
}
