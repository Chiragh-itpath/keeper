using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{

    public class UserRepo:IUserRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        
        public UserRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }


        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _dbKeeperContext.Users.ToListAsync();
        }

        public async Task<bool> Register(UserModel user)
        {
            _dbKeeperContext.Users.Add(user);
            await _dbKeeperContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
           var res=  await _dbKeeperContext.Users.FirstOrDefaultAsync(x => x.Email == email) ?? new UserModel() ;
            return res;
        }
    }
}
