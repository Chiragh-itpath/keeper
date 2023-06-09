using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;


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
            if (await _repo.Insert(model))
            {
                return new ResponseModel()
                {
                    StatusCode = EResponse.OK,
                    IsSuccess = true,
                    Message = "Project Created SuccessFully",
                };
            }
            else
            {
                return new ResponseModel()
                {
                    StatusCode = EResponse.INTERNAL_SERVER_ERROR,
                    IsSuccess = false,
                    Message = "Project Not Created",
                };
            }
        }
        public async Task<ResponseModel> GetProjects(Guid UserId)
        {
            var res = await _repo.GetProjects(UserId);
            if (res.Count > 0)
            {
                return new ResponseModel()
                {
                    StatusCode = EResponse.OK,
                    IsSuccess = true,
                    Message = "All Projects",
                    Data = res
                };
            }
            else
            {
                return new ResponseModel()
                {
                    StatusCode = EResponse.NOT_FOUND,
                    IsSuccess = false,
                    Message = "No Projects",
                };
            }
        }
    }
}
