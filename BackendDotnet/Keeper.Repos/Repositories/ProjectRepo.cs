using Dapper;
using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;
        public ProjectRepo(DbKeeperContext dbKeeperContext, IConfiguration configuration)
        {
            _dbKeeperContext = dbKeeperContext;
            _configuration = configuration;
            con= new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        }
        
        public async Task<ProjectModel> SaveAsync(ProjectModel project)
        {
            await _dbKeeperContext.Projects.AddAsync(project);
            _dbKeeperContext.SaveChanges();
            return project;
        }
        public async Task<List<ProjectModel>> GetAllAsync(Guid UserId)
        {
            return await _dbKeeperContext.Projects.Where(x => x.CreatedBy == UserId && x.IsDeleted == false).ToListAsync();

        }
        public async Task<ProjectModel> DeleteByIdAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            result.IsDeleted = true;
            return await UpdatedAsync(result);
        }

        public async Task<ProjectModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Projects.FindAsync(Id);
        }

        public async Task<ProjectModel> UpdatedAsync(ProjectModel project)
        {
            _dbKeeperContext.Entry(project).State = EntityState.Modified;
            _dbKeeperContext.SaveChanges();
            return project;
        }

        public async Task<List<ProjectModel>> GetByTagAsync(Guid userId, Guid tagId)
        {
            return await _dbKeeperContext.Projects.Where(x => (x.CreatedBy == userId && x.TagId == tagId) && x.IsDeleted == false).ToListAsync();
        }
        public async Task<IEnumerable<ProjectModel>> SharedProject(Guid userId)
        {
            string query = "select p.* from Projects p inner join ProjectUser PU on p.Id=pu.ProjectId where (pu.UserId=@uid and p.createdby!=@uid) and IsDeleted='false'";
            var result = await con.QueryAsync<ProjectModel>(query, new { uid = userId });
            return result;
        }
        public async Task<string> OwnerName(Guid projectId)
        {
            string query = " select u.email from Projects p inner join Users u on p.CreatedBy=u.Id where p.Id=@projectId";
            var result = await con.QuerySingleAsync<string>(query, new { projectId = projectId });
            return result;
        }
        public async Task<IEnumerable<string>> ContributorName(Guid projectId)
        {
            string query = " select Users.Email from Users join ProjectUser on Users.Id=ProjectUser.UserId join Projects on Projects.Id=ProjectUser.ProjectId where Projects.CreatedBy!=ProjectUser.UserId and Projects.Id=@projectId";
            var result = await con.QueryAsync<string>(query, new { projectId = projectId });
            return result;
        }
        public async Task<bool> IsContributorExist(Guid projectId,Guid userId)
        {
            string query = " select top 1 1 from ProjectUser where ProjectId=@projectId  and UserId=@uid";
            var result = await con.QueryAsync<bool>(query, new { projectId = projectId,uid=userId});
            return result.Count()>0;
        }
    }
}
