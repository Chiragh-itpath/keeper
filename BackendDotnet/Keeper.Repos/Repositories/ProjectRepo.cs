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
    public class ProjectRepo:IProjectRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        public ProjectRepo(DbKeeperContext dbKeeperContext)
        {
            _dbKeeperContext = dbKeeperContext;
        }

        public async Task<bool> Insert(ProjectModel project)
        {
            await _dbKeeperContext.Projects.AddAsync(project);
            return await _dbKeeperContext.SaveChangesAsync() == 1;
        }
        public async Task<List<ProjectModel>> GetProjects(Guid UserId)
        {
            var result=await _dbKeeperContext.Projects.Where(x => x.CreatedBy == UserId && x.IsDeleted==false).ToListAsync();
            return result;
        }
        public async Task<bool> Delete(Guid id)
        {
            var result = await _dbKeeperContext.Projects.FindAsync(id);
            if (result != null)
            {
                result.IsDeleted = true;
                _dbKeeperContext.Entry(result).State = EntityState.Modified;
                return _dbKeeperContext.SaveChanges() == 1;
            }
            else 
            {
                return false;
            }
        }

        public async Task<ProjectModel> GetProjectById(Guid Id)
        {
            var result = await _dbKeeperContext.Projects.FindAsync(Id);
            return result;    
        }

        public async Task<bool> Update(ProjectModel project)
        {
            _dbKeeperContext.Entry(project).State= EntityState.Modified;
             return await _dbKeeperContext.SaveChangesAsync()==1;
        }
    }
}
