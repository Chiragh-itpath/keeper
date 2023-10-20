using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Keeper.Repos.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly DbKeeperContext _db;

        public ProjectRepo(DbKeeperContext dbKeeperContext)
        {
            _db = dbKeeperContext;
        }

        public async Task<List<ProjectModel>> GetAllAsync(Guid UserId)
        {
            return await (from p in _db.Projects
                            .Include(p => p.Tag)
                            .Include(p => p.CreatedBy)
                            .Include(p => p.UpdatedBy)
                          where p.CreatedById == UserId
                          where p.IsDeleted == false
                          select p).ToListAsync();
        }
        public async Task<ProjectModel?> GetByIdAsync(Guid Id)
        {
            return await _db.Projects
                .Include(p => p.Tag)
                .Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }
        public async Task<Guid> SaveAsync(ProjectModel project)
        {
            await _db.Projects.AddAsync(project);
            _db.SaveChanges();
            return project.Id;
        }
        public async Task<Guid> UpdateAsync(ProjectModel project)
        {
            _db.Entry(project).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return project.Id;
        }

        public async Task DeleteAsync(ProjectModel project)
        {
            project.IsDeleted = true;
            await UpdateAsync(project);
        }

        public async Task<List<ProjectModel>> GetSharedAsync(Guid UserId)
        {
            var SharedProjects1 = await (from p in _db.Projects
                                  .Include(p => p.Tag)
                                  .Include(p => p.CreatedBy)
                                  .Include(p => p.UpdatedBy)
                                  join sp in _db.SharedProjects on new { ProjectId = p.Id, UserId, IsAccepted = true } equals new { sp.ProjectId, sp.UserId, sp.IsAccepted }
                                  where p.IsDeleted == false
                                  select p).ToListAsync();

            var SharedProjects2 = await (from p in _db.Projects
                                  .Include(p => p.Tag)
                                  .Include(p => p.CreatedBy)
                                  .Include(p => p.UpdatedBy)
                                  join sk in _db.SharedKeeps on new { ProjectId = p.Id, UserId, IsAccepted = true } equals new { sk.ProjectId, sk.UserId, sk.IsAccepted }
                                  where p.IsDeleted == false
                                  select p).Distinct().ToListAsync();
            List<ProjectModel> AllProjects = new();
            AllProjects.AddRange(SharedProjects1);
            AllProjects.AddRange(SharedProjects2);
            return AllProjects;
        }
    }
}
