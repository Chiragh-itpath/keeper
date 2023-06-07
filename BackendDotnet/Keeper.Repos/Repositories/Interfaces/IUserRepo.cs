using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Interfaces
{
    public interface IUserRepo
    {
        List<UserModel> GetAll();
    }
}
