using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IProjectRepo
    {
        Task<List<ProjectModel>> GetAllAsync(Guid userId);
        Task<ProjectModel?> GetByIdAsync(Guid Id);
        Task<Guid> SaveAsync(ProjectModel project);
        Task<Guid> UpdateAsync(ProjectModel project);
        Task DeleteAsync(ProjectModel projectid);
        Task<List<ProjectModel>> GetSharedAsync(Guid userId);
    }
     
}
