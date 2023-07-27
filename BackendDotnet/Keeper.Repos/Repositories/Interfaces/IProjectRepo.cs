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
        Task<List<ProjectModel>> GetAllAsync(Guid userId);
        Task<ProjectModel> GetByIdAsync(Guid Id);
        Task<ProjectModel> SaveAsync(ProjectModel project);
        Task<ProjectModel> DeleteByIdAsync(Guid projectid);
        Task<ProjectModel> UpdatedAsync(ProjectModel project);
        Task<List<ProjectModel>> GetByTagAsync(Guid userId,Guid tagId);
        Task<IEnumerable<ProjectModel>> SharedProject(Guid userId);
        Task<IEnumerable<string>> OwnerName(Guid projectId);

    }
}
