
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperCore.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepo.GetAll();
        }
    }
}
