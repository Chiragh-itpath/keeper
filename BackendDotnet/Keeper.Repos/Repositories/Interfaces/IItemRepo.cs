using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IItemRepo
    {
        Task<bool> SaveAsync(ItemModel item, List<FileModel> files);
        Task<bool> DeleteAsync(ItemModel item);
        Task<bool> UpdateAsync(ItemModel item, List<FileModel> files);
        Task<ItemModel> GetByIdAsync(Guid id);
        Task<IEnumerable<ItemModel>> GetAllAsync(Guid KeepId);
    }
}
