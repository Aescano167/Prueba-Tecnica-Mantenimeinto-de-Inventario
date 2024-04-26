using AutoMapper;
using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Services
{

    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBase
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual async Task<ICollection<T>> Get<T>() where T : class
        {
            var query = await _baseRepository.Query().ToListAsync();
            return _mapper.Map<List<T>>(query);
        }

        public virtual async Task<Paged<T>> GetPaged<T>(int pageSize = 10, int pageNumber = 1) where T : class
        {
            var query = _baseRepository.Query();
            var (skip, top) = Paged<T>.GetPagination(pageSize, pageNumber);
            var result = await query.Paginate<TEntity, T>(pageNumber, pageSize, _mapper);
            return result;
        }

        public virtual async Task<T> GetById<T>(Guid id) where T : class
        {
            var entity = await _baseRepository.Get(id);
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> GetByIdAsNoTraking<T>(Guid id) where T : class
        {
            var entity = await _baseRepository.GetAsNoTraking(id);
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<TResponse> Create<T, TResponse>(T dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _baseRepository.Add(entity);
            return _mapper.Map<TResponse>(entity);
        }

        public virtual async Task<TResponse> Update<T, TResponse>(T dto)
        {

            var entity = _mapper.Map<TEntity>(dto);

            entity = await _baseRepository.Update(entity);

            return _mapper.Map<TResponse>(entity);
        }

        public virtual async Task<TResponse> Patch<T, TResponse>(Guid id, T dto)
        {
            var existingEntity = await _baseRepository.Get(id);

            _mapper.Map(dto,existingEntity);

            existingEntity = await _baseRepository.Update(existingEntity);

            return _mapper.Map<TResponse>(existingEntity);
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            return true;
        }
    }
}
