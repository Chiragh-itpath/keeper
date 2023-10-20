using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Keeper.Repos.Repositories
{
    public class KeepRepo : IKeepRepo
    {
        private readonly DbKeeperContext _db;
        public KeepRepo(DbKeeperContext dbKeeperContext)
        {
            _db = dbKeeperContext;
        }

        public async Task<List<KeepModel>> GetAllAsync(Guid ProjectId)
        {
            return await _db.Keeps
                .Include(k => k.Tag)
                .Include(k => k.CreatedBy)
                .Include(k => k.UpdatedBy)
                .Where(x => x.ProjectId == ProjectId && !x.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<KeepModel>> GetAllShared(Guid projectId, Guid UserId)
        {
            return await (from k in _db.Keeps
                          join sk in _db.SharedKeeps on new { KeepId = k.Id, k.ProjectId, UserId } equals new { sk.KeepId, sk.ProjectId, sk.UserId }
                          select k).ToListAsync();
        }
        public async Task<KeepModel?> GetAsync(Guid id)
        {
            return await _db.Keeps
                .Include(k => k.Tag)
                .Include(k => k.CreatedBy)
                .Include(k => k.UpdatedBy)
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> SaveAsync(KeepModel keep)
        {
            await _db.Keeps.AddAsync(keep);
            await _db.SaveChangesAsync();
            return keep.Id;
        }

        public async Task<Guid> UpdateAsync(KeepModel Keep)
        {
            _db.Entry(Keep).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Keep.Id;
        }
        public async Task DeleteAsync(KeepModel keep)
        {
            keep.IsDeleted = true;
            await UpdateAsync(keep);
        }
    }
}
