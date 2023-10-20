using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;

namespace Keeper.Repos.Repositories
{
    public class ItemFileLInkerRepo: IItemFileLInkerRepo
    {
        private readonly DbKeeperContext _db;
        public ItemFileLInkerRepo(DbKeeperContext db)
        {
            _db = db;
        }
        public async Task<ItemFileLinkerModel> AddAsync(ItemFileLinkerModel linker)
        {
            await _db.AddAsync(linker);
            await _db.SaveChangesAsync();
            return linker;
        }
    }
}
