using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public ProjectRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        public async Task<bool> SaveAsync(ProjectModel project)
        {
            await _dbKeeperContext.Projects.AddAsync(project);
            return _dbKeeperContext.SaveChanges() == 1;
        }
        public async Task<List<ProjectModel>> GetAllAsync(Guid UserId)
        {
            return await _dbKeeperContext.Projects.Where(x => x.CreatedBy == UserId && x.IsDeleted == false).ToListAsync();
             
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var result = await _dbKeeperContext.Projects.FindAsync(id);
            result.IsDeleted = true;
            _dbKeeperContext.Entry(result).State = EntityState.Modified;
            return _dbKeeperContext.SaveChanges() == 1;
        }

        public async Task<ProjectModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Projects.FindAsync(Id);   
        }

        public async Task<bool> UpdatedAsync(ProjectModel project)
        {
            _dbKeeperContext.Entry(project).State = EntityState.Modified;
            return _dbKeeperContext.SaveChanges() == 1;
        }
    }
}
