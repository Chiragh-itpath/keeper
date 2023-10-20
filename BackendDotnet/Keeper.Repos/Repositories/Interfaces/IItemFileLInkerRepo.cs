using Keeper.Context.Model;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IItemFileLInkerRepo
    {
        Task<ItemFileLinkerModel> AddAsync(ItemFileLinkerModel linker);
    }
}
