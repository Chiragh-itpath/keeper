﻿using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Keeper.Repos.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public UserRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _dbKeeperContext.Users.ToListAsync();
        }
        public async Task<bool> RegisterAsync(UserModel user)
        {
            _dbKeeperContext.Users.Add(user);
            return _dbKeeperContext.SaveChanges()==1;
        }
        public async Task<UserModel> GetByEmailAsync(string email)
        {        
            return await _dbKeeperContext.Users.Where(x => x.Email.Contains(email)).SingleOrDefaultAsync() ?? new UserModel(); 
        }      
    }
}
