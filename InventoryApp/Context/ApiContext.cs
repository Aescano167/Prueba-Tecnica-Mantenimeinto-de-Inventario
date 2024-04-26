using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Context
{
    public interface IApiContext : IBaseDbContext { }

    public class ApiContext : BaseDbContext, IApiContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)  
        { 

        }

        public DbSet<Item> Items { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <User> Users { get; set; }
    }
}
