﻿using Keeper.Context.Model;
using Keeper.Services.Interfaces;
using Keeper.Services.Services;
using Keeper.Services.Services.Interfaces;
using KeeperCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keeper.Services.Config
{
    public static class Bootstraper
    {   
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IKeepService, KeepService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IMailService, MailService>();
        }
    }
}
