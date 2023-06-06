using KeeperCore.Repositories.Interfaces;
using KeeperCore.Services.Interfaces;
using KeeperDbContext.Model;
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
        //public UserModel GetById(Guid id)
        //{
        //    return _userRepo.GetById(id);
        //}
    }
}
