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

        public async Task<List<UserModel>> GetAll()
        {
            var res= await _dbKeeperContext.Users.ToListAsync();
            return res;
        }

        //public UserModel GetUserById(int id)
        //{
        //    var res = _dbKeeperContext.Users.FirstOrDefault(x=>x.Id);

        //}
    }
}
