using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;

namespace Keeper.Repos.Repositories
{
    public class AccountRepo:IAccountRepo
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
    }
}
