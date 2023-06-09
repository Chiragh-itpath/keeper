using Keeper.Common.Response;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IProjectRepo
    {
        Task<ResponseModel> GetProjects(Guid userId);
        Task<ResponseModel> Insert(ProjectModel project);
        
    }
}
