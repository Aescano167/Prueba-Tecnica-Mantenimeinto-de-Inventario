using InventoryApp.Context;
using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {

    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApiContext context)
            : base(context)
        {

        }
    }
}
