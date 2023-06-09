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

        public async Task<ResponseModel> Insert(ProjectModel project)
        {
            await _dbKeeperContext.Projects.AddAsync(project);
            await _dbKeeperContext.SaveChangesAsync();
            return new ResponseModel
            {
                StatusCode = EResponse.OK,
                IsSuccess = true,
                Message = "Projects Inserted",
                Data = project
            };
        }
        public async Task<ResponseModel> GetProjects(Guid UserId)
        {
            var result=await _dbKeeperContext.Projects.Where(x => x.CreatedBy == UserId).ToListAsync();
  
            if (result.Count > 0)
            {
                return new ResponseModel
                {
                    StatusCode = EResponse.OK,
                    IsSuccess = true,
                    Message = "Projects",
                    Data = result
                };
            }
            else
            {
                return new ResponseModel
                {
                    StatusCode = EResponse.NOT_FOUND,
                    IsSuccess = true,
                    Message = "No Projects",
                    Data = result
                };
            }
        }
   

    }
}
