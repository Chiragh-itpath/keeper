using Keeper.Context;
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
            return await _dbKeeperContext.Users.FirstOrDefaultAsync(x => x.Email == email) ?? new UserModel(); 
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            return await _dbKeeperContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? new UserModel();
        }
    }
}
