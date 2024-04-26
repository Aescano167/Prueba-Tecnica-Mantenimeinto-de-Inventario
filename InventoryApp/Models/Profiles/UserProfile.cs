using AutoMapper;
using InventoryApp.Models.Dtos.User;

namespace InventoryApp.Models.Profiles
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<GetUserDto, User>().ReverseMap()
                .ForMember(dest => dest.Role, op =>
                    op.MapFrom(source => source.Role.GetDescription()));

            CreateMap<User, CreateUserDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
