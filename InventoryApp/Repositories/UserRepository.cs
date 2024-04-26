using InventoryApp.Context;
using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {

    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApiContext context) 
            : base(context)
        {
            
        }
    }
}
