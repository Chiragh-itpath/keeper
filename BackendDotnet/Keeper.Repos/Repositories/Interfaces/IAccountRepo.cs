﻿using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IAccountRepo
    {
        Task<bool> RegisterAsync(UserModel user);
    }
}