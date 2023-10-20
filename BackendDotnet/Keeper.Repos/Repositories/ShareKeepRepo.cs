using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class ShareKeepRepo : IKeepShareRepo
    {
        private readonly DbKeeperContext _db;

        public ShareKeepRepo(DbKeeperContext db)
        {
            _db = db;
        }

        public async Task<SharedKeepsModel> AddAsync(SharedKeepsModel share)
        {
            await _db.AddAsync(share);
            await _db.SaveChangesAsync();
            return share;
        }
        
        public async Task<List<SharedKeepsModel>> GetAllAsync(Guid keepId)
        {
            return await _db.SharedKeeps
                .Include(x => x.User)
                .Where(x => x.KeepId == keepId)
                .ToListAsync();
        }
        public async Task<List<SharedKeepsModel>> GetAllInvited(Guid UserId)
        {
            return await _db.SharedKeeps.Where(x => x.UserId == UserId).ToListAsync();
        }
        
        public async Task<SharedKeepsModel> GetAsync(Guid id)
        {
            return await _db.SharedKeeps
                .Where(x => x.Id == id)
                .FirstAsync();
        }
        
        public async Task<SharedKeepsModel> UpdateAsync(SharedKeepsModel share)
        {
            _db.Entry(share).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return share;
        }
        
        public async Task<int> DeleteAsync(SharedKeepsModel share)
        {
            _db.SharedKeeps.Remove(share);
            return await _db.SaveChangesAsync();
        }
    }
}
