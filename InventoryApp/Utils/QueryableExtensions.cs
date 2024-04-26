using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Utils
{
    public static class QueryableExtensions
    {

        public static async Task<Paged<T>> Paginate<T>(this IQueryable<T> query, int pageNumber,
        int pageSize) where T : class
        {
            if (pageSize == 0) pageSize = 10;
            var page = ((pageNumber <= 0) ? 1 : pageNumber);
            var skip = (page - 1) * pageSize;
            return Paged<T>.Create(
                totalRecords: await query.CountAsync(),
                items: await query.Skip(skip).Take(pageSize).ToListAsync(),
                currentPage: page,
                pageSize: pageSize);
        }

        public static async Task<Paged<TDto>> Paginate<T, TDto>(this IQueryable<T> query, int pageNumber,
            int pageSize, IMapper mapper) where T : class where TDto : class
        {
            if (pageSize == 0) pageSize = 10;
            var page = ((pageNumber <= 0) ? 1 : pageNumber);
            var skip = (page - 1) * pageSize;
            var result = await query.Skip(skip).Take(pageSize).ToListAsync();
            var dtos = mapper.Map<List<TDto>>(result);
            return Paged<TDto>.Create(
                totalRecords: await query.CountAsync(),
                items: dtos,
                currentPage: page,
                pageSize: pageSize);
        }

        public static Paged<T> Paginate<T>(this ICollection<T> query, int pageNumber, int pageSize)
            where T : class
        {
            var page = ((pageNumber <= 0) ? 1 : pageNumber);
            var skip = (page - 1) * pageSize;
            return Paged<T>.Create(
                totalRecords: query.Count,
                items: query.Skip(skip).Take(pageSize).ToList(),
                currentPage: page,
                pageSize: pageSize);
        }

    }
}

