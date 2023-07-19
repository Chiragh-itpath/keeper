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
        private readonly DbKeeperContext _dbKeeperContext;

 
        public AccountRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        public async Task<bool> RegisterAsync(UserModel user)
        {
            _dbKeeperContext.Users.Add(user);
            return _dbKeeperContext.SaveChanges() == 1;
        }
        public async Task<bool> UpdatePasswordAsync(LoginVM user)
        {
            var person = await _dbKeeperContext.Users.SingleOrDefaultAsync(u => u.Email == user.Email);
            person.Password = user.Password;
            person.UpdateOn= DateTime.Now;
            return await _dbKeeperContext.SaveChangesAsync() > 0;
        }
    }
}
