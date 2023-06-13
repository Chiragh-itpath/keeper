using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;


namespace Keeper.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        public ProjectService(IProjectRepo repo)
        {
            _repo = repo;
        }
        public async Task<ResponseModel<string>> Insert(ProjectVM projectVM)
        {
            ProjectModel model = new ProjectModel
            {
                Id = Guid.NewGuid(),
                Title = projectVM.Title,
                Description = projectVM.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = Guid.Empty,
            };
            await _repo.Insert(model);
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Created SuccessFully",
                };
            }
        }
        public async Task<ResponseModel<List<ProjectModel>>> GetProjects(Guid UserId)
        {
            var result = await _repo.GetProjects(UserId);

            return new ResponseModel<List<ProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "All Projects",
                Data = result
            };
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            await _repo.Delete(id);
            return new ResponseModel<string>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Project Deleted",
            };
        }

        public async Task<ResponseModel<string>> Update(ProjectUpdateVM projectUpdate)
        {
            ProjectModel existingModel = await _repo.GetProjectById(projectUpdate.Id);
            existingModel.Title = projectUpdate.Title;
            existingModel.Description = projectUpdate.Description;
            existingModel.UpdatedOn = DateTime.Now;
            existingModel.UpdatedBy = Guid.Empty;
            await _repo.Update(existingModel);
            {
                return new ResponseModel<string>()
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Updated SuccessFully",
                };
            }

        }

        public async Task<ResponseModel<ProjectModel>> GetProjectById(Guid Id)
        {
            var result = await _repo.GetProjectById(Id);

            return new ResponseModel<ProjectModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };

        }
    }
}
