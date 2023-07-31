using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{
    public class ProjectUserRepo : IProjectUserRepo
    {
        private readonly DbKeeperContext _context;
        public ProjectUserRepo(DbKeeperContext context)
        {
            _context = context;
        }
        public async Task<ProjectUserModel> SaveAsync(ProjectUserModel model)
        {
            model.Id = Guid.NewGuid();
            await _context.ProjectUser.AddAsync(model);
            _context.SaveChanges();
            return model;
        }
    }
}
