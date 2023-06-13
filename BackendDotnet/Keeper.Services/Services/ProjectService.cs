﻿using Keeper.Common.Enums;
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
        public async Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM)
        {
            ProjectModel model = new ProjectModel
            {
                Id = Guid.NewGuid(),
                Title = projectVM.Title,
                Description = projectVM.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = Guid.Empty,
            };
            await _repo.SaveAsync(model);
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Created SuccessFully",
                };
            }
        }
        public async Task<ResponseModel<List<ProjectModel>>> GetAllAsync(Guid UserId)
        {
            var result = await _repo.GetAllAsync(UserId);

            return new ResponseModel<List<ProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "All Projects",
                Data = result
            };
        }

        public async Task<ResponseModel<string>> DeleteByIdAsync(Guid id)
        {
            await _repo.DeleteByIdAsync(id);
            return new ResponseModel<string>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Project Deleted",
            };
        }

        public async Task<ResponseModel<string>> UpdatedAsync(ProjectUpdateVM projectUpdate)
        {
            ProjectModel existingModel = await _repo.GetByIdAsync(projectUpdate.Id);
            existingModel.Title = projectUpdate.Title;
            existingModel.Description = projectUpdate.Description;
            existingModel.UpdatedOn = DateTime.Now;
            existingModel.UpdatedBy = Guid.Empty;
            await _repo.UpdatedAsync(existingModel);
            {
                return new ResponseModel<string>()
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Updated SuccessFully",
                };
            }

        }

        public async Task<ResponseModel<ProjectModel>> GetByIdAsync(Guid Id)
        {
            var result = await _repo.GetByIdAsync(Id);

            return new ResponseModel<ProjectModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };

        }
    }
}
