using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IItemRepo
    {
        Task<List<ItemModel>> GetAllAsync(Guid KeepId);
        Task<ItemModel?> GetAsync(Guid ItemId);
        Task<Guid> SaveAsync(ItemModel item);
        Task<Guid> Update(ItemModel item);
        Task Delete(ItemModel item);
    }
}
