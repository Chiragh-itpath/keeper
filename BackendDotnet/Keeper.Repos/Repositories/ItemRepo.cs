using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class ItemRepo : IItemRepo
    {
        private readonly DbKeeperContext _db;
        public ItemRepo(DbKeeperContext dbKeeperContext)
        {
            _db = dbKeeperContext;
        }

        public async Task<List<ItemModel>> GetAllAsync(Guid KeepId)
        {
            return await _db.Items
                .Include(i => i.CreatedBy)
                .Include(i => i.UpdatedBy)
                .Where(x => x.KeepId == KeepId && !x.IsDeleted).ToListAsync();
        }

        public async Task<ItemModel?> GetAsync(Guid ItemId)
        {
            return await _db.Items
                .Include(i => i.CreatedBy)
                .Include(i => i.UpdatedBy)
                .Where(i => !i.IsDeleted).FirstOrDefaultAsync(x => x.Id == ItemId);
        }

        public async Task<Guid> SaveAsync(ItemModel item)
        {
            await _db.Items.AddAsync(item);
            _db.SaveChanges();
            return item.Id;
        }

        public async Task<Guid> Update(ItemModel item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return item.Id;
        }
        public async Task Delete(ItemModel item)
        {
            item.IsDeleted = true;
            await Update(item);
        }
    }
}
