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

        public async Task<IEnumerable<KeepModel>> GetAllAsync(Guid projectId,Guid UserId)
        {
            var result = Guid.Empty;
            var con = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            try
            {
                var query = "select top 1 km.KeepsId from KeepModelUserModel km join ProjectModelUserModel pm on km.UsersId = @usersId where pm.ProjectsId = @projectId";
                result = await con.QuerySingleOrDefaultAsync<Guid>(query, new { projectId = projectId, usersId = UserId });

                if (result != Guid.Empty)
                {
                    var Allkeeps = "select distinct k.Id, k.* from Keeps k join KeepModelUserModel ku on  k.Id = ku.KeepsId join ProjectModelUserModel pu on pu.ProjectsId = k.ProjectId and pu.UsersId = ku.UsersId and pu.UsersId = @usersId and pu.ProjectsId = @projectsId where k.IsDeleted=0";
                    var keeps = await con.QueryAsync<KeepModel>(Allkeeps, new { usersId = UserId, projectsId = projectId });
                    return keeps;
                }
                else
                {
                    var keep = "select k.* from Keeps k where k.ProjectId = @projectId";
                    var keepresult = await con.QueryAsync<KeepModel>(keep, new { projectId = projectId });
                    return keepresult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
