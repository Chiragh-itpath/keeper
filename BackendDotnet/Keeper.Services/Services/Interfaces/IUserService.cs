
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
    }
}
