using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Repos.Repositories
{
    public class ShareProjectRepo : IProjectShareRepo
    {
        private readonly DbKeeperContext _db;

        public ShareProjectRepo(DbKeeperContext db)
        {
            _db = db;
        }

        public async Task<SharedProjectsModel> AddAsync(SharedProjectsModel share)
        {
            await _db.SharedProjects.AddAsync(share);
            await _db.SaveChangesAsync();
            return share;
        }

        public async Task<List<SharedProjectsModel>> GetAllAsync(Guid ProjectId)
        {
            return await _db.SharedProjects
                .Include(x => x.User)
                .Where(x => x.ProjectId == ProjectId).ToListAsync();
        }
        public async Task<List<SharedProjectsModel>> GetAllInvited(Guid UserId)
        {
            return await _db.SharedProjects.Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task<SharedProjectsModel> GetAsync(Guid id)
        {
            return await _db.SharedProjects
                .Where(x => x.Id == id)
                .FirstAsync();
        }

        public async Task<SharedProjectsModel> UpdateAsync(SharedProjectsModel share)
        {
            _db.Entry(share).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return share;
        }

        public async Task<int> DeleteAsync(SharedProjectsModel share)
        {
            _db.SharedProjects.Remove(share);
            return await _db.SaveChangesAsync();
        }

        public async Task<SharedProjectsModel?> GetAsync(Guid projectId, Guid userId)
        {
            return await _db.SharedProjects
                .Where(x => x.ProjectId == projectId && x.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
