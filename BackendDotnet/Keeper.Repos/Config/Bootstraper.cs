using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Config
{
    public static class Bootstraper
    {
        public static void RegisterRepos(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo,UserRepo>();
            services.AddTransient<ITagRepo, TagRepo>();
            services.AddTransient<IProjectRepo, ProjectRepo>();
        }
    }
}
