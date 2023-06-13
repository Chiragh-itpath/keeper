﻿using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
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
            if (await _repo.Insert(model))
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Created SuccessFully",
                };
            }
            else
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.INTERNAL_SERVER_ERROR,
                    IsSuccess = false,
                    Message = "Project Not Created",
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

        public async Task<ResponseModel> Delete(Guid id)
        {
            if (await _repo.Delete(id))
            {
                return new ResponseModel() 
                { 
                    StatusCode = StatusType.OK,
                    IsSuccess = true,
                    Message="Project Deleted",
                };
            }
            else
            {
                return new ResponseModel()
                {
                    StatusCode = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Project Not Found",
                };

            }
        }

        public async Task<ResponseModel> Update(ProjectVM project)
        {
            ProjectModel model = new ProjectModel
            {   Id=project.Id,
                Title = project.Title,
                Description = project.Description,
                UpdatedOn=DateTime.Now,
                UpdatedBy=Guid.Empty
            };
            if (await _repo.Update(model))
            {
                return new ResponseModel()
                {
                    StatusCode = StatusType.OK,
                    IsSuccess = true,
                    Message = "Project Updated SuccessFully",
                };
            }
            else
            {
                return new ResponseModel()
                {
                    StatusCode = StatusType.INTERNAL_SERVER_ERROR,
                    IsSuccess = false,
                    Message = "Project Not Created",
                };
            }



        }
    }
}
