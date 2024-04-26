using AutoMapper;
using InventoryApp.Models.Dtos.Product;
using InventoryApp.Models.Dtos.User;

namespace InventoryApp.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
