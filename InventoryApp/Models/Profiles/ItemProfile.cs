using AutoMapper;
using InventoryApp.Models.Dtos.Item;
using InventoryApp.Models.Dtos.Product;

namespace InventoryApp.Models.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, CreateItemDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
