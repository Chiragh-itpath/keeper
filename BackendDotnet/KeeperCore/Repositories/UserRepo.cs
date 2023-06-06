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
    public class UserRepo:GenericRepo<UserModel>,IGenericRepo<UserModel>,IUserRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        private readonly IGenericRepo<UserModel> _genericRepo;

        public UserRepo(DbKeeperContext dbKeeperContext, IGenericRepo<UserModel> genericRepo) : base(dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
            _genericRepo = genericRepo;

        }
    }
}
