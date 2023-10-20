using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface ITagRepo
    {
        List<TagModel> GetAll(Guid userId);
        Task<TagModel?> GetByIdAsync(Guid id);
        Task<TagModel> AddAsync(TagModel tag);
    }
}
