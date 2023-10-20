using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class TagRepo : ITagRepo
    {
        private readonly DbKeeperContext _db;
        public TagRepo(DbKeeperContext dbKeeperContext)
        {
            _db = dbKeeperContext;
        }

        public List<TagModel> GetAll(Guid userId)
        {
            return _db.Tags.Where(t => t.UserId == userId).ToList();
        }

        public async Task<TagModel?> GetByIdAsync(Guid id)
        {
            return await _db.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TagModel> AddAsync(TagModel tag)
        {
            await _db.Tags.AddAsync(tag);
            await _db.SaveChangesAsync();
            return tag;
        }
    }
}
