﻿using Keeper.Services.Interfaces;
using Keeper.Services.Services;
using Keeper.Services.Services.Interfaces;
using KeeperCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
