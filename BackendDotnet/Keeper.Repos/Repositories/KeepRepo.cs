using Dapper;
using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Migrations;
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
using System.Web.Http.Results;

namespace Keeper.Repos.Repositories
{
    public class KeepRepo : IKeepRepo
    {
        private readonly DbKeeperContext _dbKeeperContext;
        private readonly IConfiguration _configuration;
        public KeepRepo(DbKeeperContext dbKeeperContext, IConfiguration configuration)
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

        public async Task<ResponseModel<IEnumerable<KeepModel>>> GetAllAsync(Guid projectId, Guid UserId, int isShared)
        {
            var con = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            try
            {
                var query = "select top 1 * from ProjectUser where ProjectId=@projectsId";
                var sharedkeep = await con.QueryFirstOrDefaultAsync<ProjectUserModel>(query, new { projectsId = projectId });
                if (isShared == 0 || sharedkeep.HasFullAccess == true)
                {
                    var AllKeeps = "select keeps.* from keeps join Projects on Keeps.ProjectId=Projects.Id where Projects.Id=@projectId and keeps.IsDeleted='0'";
                    var result = await con.QueryAsync<KeepModel>(AllKeeps, new { projectId = projectId });
                    return new ResponseModel<IEnumerable<KeepModel>>() {
                        IsSuccess = true,
                        Message = "All Keeps",
                        Data = result,
                        StatusName=StatusType.SUCCESS
                    };

                }
                query = "select distinct k.* from Keeps k join keepUser ku on k.Id = ku.KeepId join ProjectUser pu on ku.UserId = pu.UserId and pu.UserId = @userId where pu.HasFullAccess = '0' and k.ProjectId = @projectId";
                var keeps = await con.QueryAsync<KeepModel>(query, new { userId = UserId, projectId = projectId });
                return new ResponseModel<IEnumerable<KeepModel>>()
                {
                    IsSuccess = true,
                    Message = "Shared Keep",
                    Data = keeps,
                    StatusName = StatusType.SUCCESS
                };
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
            string query = "select distinct k.* from Keeps k inner join KeepModelUserModel KU on k.Id=KU.KeepsId where (KU.UsersId=@uid and k.createdby!=@uid) and IsDeleted='false'";
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
