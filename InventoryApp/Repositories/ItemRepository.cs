using InventoryApp.Context;
using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {

    }

    public class ItemRepository : BaseRepository<Item>, IItemRepository

    {
        public ItemRepository(ApiContext context)
            :base(context)
        {
            
        }
    }
}
