
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class ItemRepo : IItemRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public ItemRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        public async Task<bool> SaveAsync(ItemModel item, List<FileModel> files)
        {
            files.ForEach(file =>
            {
                file.Items?.Add(item);
                item.Files?.Add(file);
            });
            await _dbKeeperContext.Items.AddAsync(item);

            await _dbKeeperContext.Files.AddRangeAsync(files);
            return await _dbKeeperContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(ItemModel item, List<FileModel> files)
        {
            files.ForEach(file =>
            {
                file.Items?.Add(item);
                item.Files?.Add(file);
            });
            _dbKeeperContext.Items.Update(item);
            await _dbKeeperContext.Files.AddRangeAsync(files);
            return await _dbKeeperContext.SaveChangesAsync() > 0;
        }
        public async Task<ItemModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Items.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false) ?? new ItemModel();
        }

        public async Task<bool> DeleteAsync(ItemModel item)
        {
            _dbKeeperContext.Items.Update(item);
            return await _dbKeeperContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ItemModel>> GetAllAsync(Guid KeepId)
        {
            return await _dbKeeperContext.Items.Where(x => x.KeepId == KeepId && x.IsDeleted == false).ToListAsync();
        }
    }
}
