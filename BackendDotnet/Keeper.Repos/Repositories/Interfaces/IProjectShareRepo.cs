using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IProjectShareRepo
    {
        Task<SharedProjectsModel> AddAsync(SharedProjectsModel share);
        Task<SharedProjectsModel> GetAsync(Guid id);
        Task<SharedProjectsModel> UpdateAsync(SharedProjectsModel share);
        Task<int> DeleteAsync(SharedProjectsModel share);
        Task<List<SharedProjectsModel>> GetAllAsync(Guid ProjectId);
        Task<List<SharedProjectsModel>> GetAllInvited(Guid UserId);
        Task<SharedProjectsModel?> GetAsync(Guid projectId, Guid userId);
    }
}
