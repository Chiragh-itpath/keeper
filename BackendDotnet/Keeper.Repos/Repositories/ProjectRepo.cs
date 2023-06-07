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

        public async Task<ProjectModel> Insert(ProjectModel project)
        {
            await _dbKeeperContext.Projects.AddAsync(project);
            var res= await _dbKeeperContext.SaveChangesAsync();
            return project;
        }
   

    }
}
