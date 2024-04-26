using AutoMapper;
using InventoryApp.Models;
using InventoryApp.Models.Dtos.User;
using InventoryApp.Repositories;
using InventoryApp.Utils;

namespace InventoryApp.Services
{
    public interface IUserService : IBaseService<User> { }

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository baseRepository, IMapper mapper)
            : base(baseRepository, mapper)
        {

        }

        public override async Task<TResponse> Create<T, TResponse>(T value)
        {
            var dto = value as CreateUserDto;
            var entity = _mapper.Map<User>(dto);
            //entity.Photo = ManipulatePhoto.GenerateBase64(dto.Photo);
            entity = await _baseRepository.Add(entity);
            return _mapper.Map<TResponse>(entity);
        }
    }

}
