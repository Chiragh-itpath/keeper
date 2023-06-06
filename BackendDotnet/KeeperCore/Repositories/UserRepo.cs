using KeeperCore.Repositories.Interfaces;
using KeeperDbContext;
using KeeperDbContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperCore.Repositories
{

    public class UserRepo:IUserRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        
        public UserRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }


        public List<UserModel> GetAll()
        {
            return _dbKeeperContext.Users.ToList();
        }

        //public UserModel GetUserById(int id)
        //{
        //    var res = _dbKeeperContext.Users.FirstOrDefault(x=>x.Id);

        //}
    }
}
