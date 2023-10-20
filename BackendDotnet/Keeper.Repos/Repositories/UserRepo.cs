using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DbKeeperContext _db;
        public UserRepo(DbKeeperContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        
        public bool UpdateUser(UserModel user)
        {
            _db.Update(user);
            return _db.SaveChanges() == 1;
        }
        public async Task<List<UserModel>> GetEmailList(string email)
        {
            return await _db.Users
                .Where(x => x.Email.StartsWith(email))
                .ToListAsync();
        }

        public async Task<UserModel?> GetById(Guid userId)
        {
            return await _db.Users
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
