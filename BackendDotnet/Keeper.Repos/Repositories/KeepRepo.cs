using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{
    public class KeepRepo:IKeepRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public KeepRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        public async Task<bool> DeleteByIdAsync(Guid keepid)
        {
            var result = await GetByIdAsync(keepid);
            result.IsDeleted = true;
            return await UpdatedAsync(result);
        }

        public async Task<List<KeepModel>> GetAllAsync(Guid projectId)
        {
            return await _dbKeeperContext.Keeps.Where(x => x.ProjectId == projectId && x.IsDeleted == false).ToListAsync();
        }

        public async Task<KeepModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Keeps.FindAsync(Id);
        }

        public async Task<bool> SaveAsync(KeepModel keep)
        {
            await _dbKeeperContext.Keeps.AddAsync(keep);
            return _dbKeeperContext.SaveChanges() == 1;
        }

        public async Task<bool> UpdatedAsync(KeepModel keepModel)
        {
            _dbKeeperContext.Entry(keepModel).State = EntityState.Modified;
            return _dbKeeperContext.SaveChanges() == 1;
        }
    }
}
