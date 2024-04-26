using InventoryApp.Context;
using InventoryApp.Repositories;
using InventoryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace InventoryApp.Extension
{
    public class AppSetup
    {
        public ConfigurationManager Configuration { get; set; }

        public AppSetup(ConfigurationManager configuration)
        {

            Configuration = configuration;

        }

        public void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("InventoryPolicy", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();

                    builder.SetIsOriginAllowed(x => true);                                  
                });
            });
        }

        public void AddDbContext(IServiceCollection services)
        {
            string stringConnection = string.Format("filename={0}/DataBase.db", AppDomain.CurrentDomain.BaseDirectory);
            services.AddDbContext<ApiContext>(opt => opt.UseSqlite(stringConnection));
        }

        public void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryApp", Version = "v1" });
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IItemService, ItemService>();
        }

        public void ConfigureRepository(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
        }
    }
}
