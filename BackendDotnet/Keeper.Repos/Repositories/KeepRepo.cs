using Dapper;
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
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories
{
    public class KeepRepo : IKeepRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;        
        private readonly IConfiguration _configuration;
        public KeepRepo(DbKeeperContext dbKeeperContext,IConfiguration configuration)
        {
            _dbKeeperContext = dbKeeperContext;
            _configuration = configuration;
        }

        public async Task<bool> DeleteByIdAsync(Guid keepid)
        {
            var result = await GetByIdAsync(keepid);
            result.IsDeleted = true;
            return await UpdatedAsync(result);
        }

        public async Task<IEnumerable<KeepModel>> GetAllAsync(Guid projectId,Guid UserId,int isShared)
        {
            var con = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            if (isShared==1)
            {
                try
                {
                    var query = "select k.* from Keeps k join KeepModelUserModel ku on  k.Id = ku.KeepsId and ku.UsersId = @usersId join ProjectModelUserModel pu on pu.ProjectsId = k.ProjectId and pu.ProjectsId =@projectsId and pu.UsersId = ku.UsersId ";
                    var sharedkeep = await con.QueryAsync<KeepModel>(query, new { usersId = UserId, projectsId = projectId });
                    if (sharedkeep.Count() == 0)
                    {
                        var AllKeeps = "select * from keeps where keeps.ProjectId=@projectId";
                        var keeps = await con.QueryAsync<KeepModel>(AllKeeps, new { projectId = projectId });
                        return keeps;
                    }
                    else
                    {
                        return sharedkeep.ToList();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var AllKeeps = "select * from keeps where keeps.ProjectId=@projectId";
                    var result = await con.QueryAsync<KeepModel>(AllKeeps, new { projectId = projectId });
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }
        public async Task<KeepModel> GetByIdAsync(Guid Id)
        {
            return await _dbKeeperContext.Keeps.FindAsync(Id);
        }

        public async Task<List<KeepModel>> GetByTagAsync(Guid userId, Guid tagId)
        {
            return await _dbKeeperContext.Keeps.Where(x => (x.CreatedBy == userId && x.TagId == tagId) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<KeepModel> SaveAsync(KeepModel keep)
        {
                await _dbKeeperContext.Keeps.AddAsync(keep);
                _dbKeeperContext.SaveChangesAsync();
                return keep;
        }

        public async Task<IEnumerable<KeepModel>> SharedKeepAsync(Guid userId)
        {
            var con = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            string query = "select k.* from Keeps k inner join KeepModelUserModel KU on k.Id=KU.KeepsId where (KU.UsersId=@uid and k.createdby!=@uid) and IsDeleted='false'";
            var result = await con.QueryAsync<KeepModel>(query, new { uid = userId });
            return result;
        }

        public async Task<bool> UpdatedAsync(KeepModel keepModel)
        {
            _dbKeeperContext.Entry(keepModel).State = EntityState.Modified;
            return _dbKeeperContext.SaveChanges() == 1;
        }
    }
}
