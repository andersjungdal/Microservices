namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Db.Product, Models.Product>()
                .ReverseMap();
            //CreateMap<Models.Product, Db.Product>();
        }
    }
}
