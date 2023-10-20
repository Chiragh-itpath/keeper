using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IKeepRepo
    {
        Task<List<KeepModel>> GetAllAsync(Guid ProjectId);
        Task<List<KeepModel>> GetAllShared(Guid projectId, Guid userId);
        Task<KeepModel?> GetAsync(Guid id);
        Task<Guid> SaveAsync(KeepModel keep);
        Task<Guid> UpdateAsync(KeepModel Keep);
        Task DeleteAsync(KeepModel keep);
    }
}
