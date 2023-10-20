using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IKeepShareRepo
    {
        Task<SharedKeepsModel> AddAsync(SharedKeepsModel share);
        Task<List<SharedKeepsModel>> GetAllAsync(Guid keepId);
        Task<List<SharedKeepsModel>> GetAllInvited(Guid UserId);
        Task<SharedKeepsModel> GetAsync(Guid id);
        Task<SharedKeepsModel> UpdateAsync(SharedKeepsModel share);
        Task<int> DeleteAsync(SharedKeepsModel share);
    }
}
