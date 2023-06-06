using KeeperCore.Repositories;
using KeeperCore.Repositories.Interfaces;
using KeeperCore.Services;
using KeeperCore.Services.Interfaces;
using KeeperDbContext;
using Microsoft.EntityFrameworkCore;

namespace KeeperMain.Config
{
    public static class Bootstrap
    {
        public static void RegisterDbContext(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<DbKeeperContext>(option => option.UseSqlServer(ConnectionString));
        }
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
