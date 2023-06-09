using Keeper.Common.Enums;
using Keeper.Common.Response;
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
            var result=await _dbKeeperContext.Projects.Where(x => x.CreatedBy == UserId).ToListAsync();
            return result;
        }
   

    }
}
