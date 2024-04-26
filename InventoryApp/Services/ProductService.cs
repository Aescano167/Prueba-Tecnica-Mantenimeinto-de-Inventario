using AutoMapper;
using InventoryApp.Models;
using InventoryApp.Models.Dtos.Product;
using InventoryApp.Repositories;

namespace InventoryApp.Services
{
    public interface IProductService : IBaseService<Product> { }

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IProductRepository baseRepository, IMapper mapper)
            : base(baseRepository, mapper)
        {
            
        }
    }
}
