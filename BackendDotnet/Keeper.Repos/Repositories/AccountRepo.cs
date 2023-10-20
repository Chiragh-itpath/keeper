using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly DbKeeperContext _db;


        public AccountRepo(DbKeeperContext dbKeeperContext)
        {
            _db = dbKeeperContext;
        }

        public async Task<bool> RegisterAsync(UserModel user)
        {
            _db.Users.Add(user);
            return await _db.SaveChangesAsync() == 1;
        }
        public async Task<bool> UpdatePasswordAsync(UserModel user)
        {
            _db.Entry(user).State = EntityState.Modified;
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
