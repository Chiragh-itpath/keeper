using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IProjectUserRepo
    {
        Task<ProjectUserModel> SaveAsync(ProjectUserModel model);
    }
}
