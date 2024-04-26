using AutoMapper;
using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Services;

namespace InventoryApp.Services
{
    public interface IItemService : IBaseService<Item>
    {

    }

    public class ItemService : BaseService<Item>, IItemService
    {
        public ItemService(IItemRepository baseRepository, IMapper mapper)
            :base(baseRepository, mapper)
        {
            
        }

    }
}