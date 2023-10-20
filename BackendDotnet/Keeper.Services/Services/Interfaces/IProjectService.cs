using Keeper.Common.Response;
using Keeper.Common.ViewModels;


namespace Keeper.Services.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ResponseModel<List<ProjectViewModel>>> GetAllAsync(Guid UserId);
        Task<ResponseModel<ProjectViewModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<ProjectViewModel>> SaveAsync(AddProject addProject,Guid userId);
        Task<ResponseModel<ProjectViewModel>> UpdateAsync(EditProject editProject, Guid userId);
        Task<ResponseModel<string>> DeleteByIdAsync(Guid Id);
        Task<ResponseModel<List<ProjectViewModel>>> GetShared(Guid userId);
    }
}
