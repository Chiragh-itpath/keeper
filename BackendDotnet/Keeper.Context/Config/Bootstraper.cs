using Keeper.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Context.Config
{
    public static class Bootstraper
    {
        public static void RegisterDbContext(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<DbKeeperContext>(option => option.UseSqlServer(ConnectionString));
        }
    }
}
