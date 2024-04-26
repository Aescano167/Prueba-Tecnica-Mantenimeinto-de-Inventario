using InventoryApp.Models;
using InventoryApp.Utils;

namespace InventoryApp.Services
{
    public interface IBaseService<TEntity> where TEntity : class, IBase
    {
        Task<ICollection<T>> Get<T>() where T : class;

        Task<Paged<T>> GetPaged<T>(int pageSize = 10, int pageNumber = 1) where T : class;

        Task<T> GetById<T>(Guid id) where T : class;

        Task<T> GetByIdAsNoTraking<T>(Guid id) where T : class;

        Task<TResponse> Create<T, TResponse>(T dto);

        Task<TResponse> Update<T, TResponse>(T dto);

        Task<TResponse> Patch<T, TResponse>(Guid id, T dto);

        Task<bool> Delete(Guid id);
    }

}

