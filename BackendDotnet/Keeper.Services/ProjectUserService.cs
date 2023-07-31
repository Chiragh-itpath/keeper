using Keeper.Context.Migrations;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services
{
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectUserRepo _repo;

        public ProjectUserService(IProjectUserRepo repo, IProjectRepo projectRepo)
        {
            _repo = repo;
        }

        public async Task<ProjectUserModel> SaveAsync(Guid UserId, Guid ProjectId, bool isShared)
        {
            ProjectUserModel projectUser = new()
            {
                ProjectId = ProjectId,
                UserId = UserId,
                HasFullAccess = isShared
            };
            return await _repo.SaveAsync(projectUser);
        }
    }
}
