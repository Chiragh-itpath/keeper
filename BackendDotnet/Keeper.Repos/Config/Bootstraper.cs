using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Keeper.Repos.Config
{
    public static class Bootstraper
    {
        public static IServiceCollection RegisterRepos(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<ITagRepo, TagRepo>();
            services.AddTransient<IProjectRepo, ProjectRepo>();
            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IKeepRepo, KeepRepo>();
            services.AddTransient<IItemRepo, ItemRepo>();
            services.AddTransient<IFileRepo, FileRepo>();
            services.AddTransient<IItemFileLInkerRepo, ItemFileLInkerRepo>();
            services.AddTransient<IProjectShareRepo, ShareProjectRepo>();
            services.AddTransient<IKeepShareRepo, ShareKeepRepo>();
            return services;
        }
    }
}
