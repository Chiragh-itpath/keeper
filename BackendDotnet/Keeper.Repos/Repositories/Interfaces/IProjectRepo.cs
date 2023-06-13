using Keeper.Common.Response;
using Keeper.Common.View_Models;
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
        Task<List<ProjectModel>> GetProjects(Guid userId);
        Task<ProjectModel> GetProjectById(Guid Id);
        Task<bool> Insert(ProjectModel project);
        Task<bool> Delete(Guid projectid);
        Task<bool> Update(ProjectModel project);

    }
}
