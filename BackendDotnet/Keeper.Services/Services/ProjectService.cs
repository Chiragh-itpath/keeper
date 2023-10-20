using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly ITagService _tag;
        public ProjectService(IProjectRepo repo, ITagService tagService)
        {
            _repo = repo;
            _tag = tagService;

        }
        public async Task<ResponseModel<List<ProjectViewModel>>> GetAllAsync(Guid UserId)
        {
            var result = await _repo.GetAllAsync(UserId);

            var projects = result
                .Select(r => new ProjectViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    CreatedBy = r.CreatedBy.Email,
                    CreatedOn = r.CreatedOn,
                    UpdatedBy = r.UpdatedBy?.Email,
                    UpdatedOn = r.UpdatedOn,
                    Tag = r.Tag?.Title
                })
                .ToList();

            return new ResponseModel<List<ProjectViewModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = projects
            };
        }
        public async Task<ResponseModel<ProjectViewModel>> GetByIdAsync(Guid Id)
        {
            var result = await _repo.GetByIdAsync(Id);
            if (result == null)
            {
                return new ResponseModel<ProjectViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                };
            }

            ProjectViewModel project = new()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Tag = result.Tag?.Title,
                CreatedBy = result.CreatedBy.Email,
                UpdatedBy = result.UpdatedBy?.Email,
                CreatedOn = result.CreatedOn,
                UpdatedOn = result.UpdatedOn,

            };
            return new ResponseModel<ProjectViewModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = project
            };

        }
        public async Task<ResponseModel<ProjectViewModel>> SaveAsync(AddProject addProject, Guid userId)
        {
            ProjectModel project = new()
            {
                Title = addProject.Title,
                Description = addProject.Description,
                CreatedOn = DateTime.Now,
                CreatedById = userId
            };
            if (!string.IsNullOrEmpty(addProject.Tag))
            {
                var tag = await _tag.AddAsync(addProject.Tag, userId, TagType.PROJECT);
                project.TagId = tag?.Id;
            }
            var projectId = await _repo.SaveAsync(project);
            var res = await GetByIdAsync(projectId);
            res.Message = "Project Created";
            return res;
        }
        public async Task<ResponseModel<ProjectViewModel>> UpdateAsync(EditProject editProject, Guid userId)
        {
            var project = await _repo.GetByIdAsync(editProject.Id);
            if (project == null)
            {
                return new ResponseModel<ProjectViewModel>
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "Project Not Found"
                };
            }
            project.Title = editProject.Title;
            project.Description = editProject.Description;
            project.UpdatedById = userId;
            project.UpdatedOn = DateTime.Now;
            if (!string.IsNullOrEmpty(editProject.Tag))
            {
                var tag = await _tag.AddAsync(editProject.Tag, project.CreatedById, TagType.PROJECT);
                project.TagId = tag?.Id;
            }
            else
            {
                project.TagId = null;
            }
            var projectId = await _repo.UpdateAsync(project);
            var res = await GetByIdAsync(projectId);
            res.Message = "Project Updated";
            return res;
        }
        public async Task<ResponseModel<string>> DeleteByIdAsync(Guid id)
        {
            var project = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(project!);
            return new ResponseModel<string>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Project Deleted",
                Data = id.ToString()
            };
        }
        public async Task<ResponseModel<List<ProjectViewModel>>> GetShared(Guid userId)
        {
            var result = await _repo.GetSharedAsync(userId);

            var projects = result
                .Select(r => new ProjectViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    CreatedBy = r.CreatedBy.Email,
                    CreatedOn = r.CreatedOn,
                    UpdatedBy = r.UpdatedBy?.Email,
                    UpdatedOn = r.UpdatedOn,
                    Tag = r.Tag?.Title,
                    IsShared = true
                })
                .ToList();

            return new ResponseModel<List<ProjectViewModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = projects
            };
        }
    }
}
