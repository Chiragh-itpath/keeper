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
    public class UserRepo : IUserRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;


        public UserRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;


        }
    }
}
