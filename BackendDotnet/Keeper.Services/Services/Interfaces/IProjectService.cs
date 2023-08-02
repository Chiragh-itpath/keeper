using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM);
        Task<ResponseModel<List<ProjectVM>>> GetAllAsync(Guid UserId);
        Task<ResponseModel<ProjectModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<string>> DeleteByIdAsync(Guid Id);
        Task<ResponseModel<string>> UpdatedAsync(ProjectVM project);
        Task<ResponseModel<List<ProjectModel>>> GetByTagAsync(Guid userId, Guid tagId);
        Task<ResponseModel<List<ProjectVM>>> SharedProjects(Guid userId);
        Task<string> OwnerName(Guid projectId);
        Task<IEnumerable<string>> ContributorName(Guid projectId);
    }
}
