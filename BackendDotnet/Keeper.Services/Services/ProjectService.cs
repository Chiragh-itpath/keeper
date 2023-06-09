using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepo _repo;
        public ProjectService(IProjectRepo repo)
        {
            _repo = repo;
        }
        public async Task<ResponseModel> Insert(ProjectVM projectVM)
        {
            
            ProjectModel model = new ProjectModel
            {
                Id = Guid.NewGuid(),
                Title = projectVM.Title,
                Description = projectVM.Description,
                CreatedOn = DateTime.MinValue,
                CreatedBy = Guid.Empty,
            };
            return await _repo.Insert(model);
        }
        public async Task<ResponseModel> GetProjects(Guid UserId)
        {
            return await _repo.GetProjects(UserId);
        }
        
    }
}
