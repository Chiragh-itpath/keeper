using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Keeper.Repos.Repositories
{
    public class TagRepo : ITagRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public TagRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

       
        public async Task<IEnumerable<TagModel>> GetAllAsync()
        {
            return await _dbKeeperContext.Tags.ToListAsync();
        }

        public async Task<TagModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Tags.FindAsync(Id);
        }
        
        public async Task<IEnumerable<TagModel>> GetByTypeAsync(TagType type)
        {
            return await _dbKeeperContext.Tags.Where(t=>t.Type==type).ToListAsync();
        }
        public async Task<TagModel> GetByTitleAsync(string title)
        {
            return await _dbKeeperContext.Tags.FirstOrDefaultAsync(t=>t.Title== title);
        }

        public async Task<TagModel> SaveAsync(TagModel tag)
        {
            await _dbKeeperContext.Tags.AddAsync(tag);
            if (await _dbKeeperContext.SaveChangesAsync() > 0)
                return tag;
            return null; 
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var res=await _dbKeeperContext.Tags.FindAsync(id);
            if (res != null)
            {
                _dbKeeperContext.Tags.Remove(res);
                _dbKeeperContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
