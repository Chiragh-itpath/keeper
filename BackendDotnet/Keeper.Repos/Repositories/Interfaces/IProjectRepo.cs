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
        Task<bool> DeleteByIdAsync(Guid projectid);
        Task<bool> UpdatedAsync(ProjectModel project);
        Task<List<ProjectModel>> GetByTagAsync(Guid userId,Guid tagId);

    }
}
