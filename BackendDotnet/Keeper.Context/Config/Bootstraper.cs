using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keeper.Context.Config
{
    public static class Bootstraper
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<DbKeeperContext>(option => option.UseSqlServer(ConnectionString));
        }


    }
}
