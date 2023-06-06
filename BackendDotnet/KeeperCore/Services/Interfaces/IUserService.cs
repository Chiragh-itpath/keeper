using KeeperDbContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperCore.Services.Interfaces
{
    public interface IUserService
    {
        UserModel GetById(Guid id);
        public List<UserModel> GetUsers();
    }
}
