using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;


namespace Keeper.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly ITagService _tagService;
        public ProjectService(IProjectRepo repo, ITagService tagService)
        {
            _repo = repo;
            _tagService = tagService;
        }
        public async Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM)
        {
            var tagId = Guid.NewGuid();
            if (projectVM.TagTitle != null && projectVM.TagTitle != "")
            {
                var tag = await _tagService.GetByTitleAsync(projectVM.TagTitle);
                if (tag.Data == null)
                {
                    TagModel tagModel = new TagModel()
                    {
                        Id = tagId,
                        Title = projectVM.TagTitle,
                        Type = TagType.PROJECT
                    };
                    await _tagService.SaveAsync(tagModel);
                }
                else
                {
                    tagId = tag.Data.Id;
                }
            }
            else
                tagId = Guid.Empty;

            ProjectModel model = new ProjectModel
            {
                Title = projectVM.Title,
                Description = projectVM.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = projectVM.CreatedBy,
                TagId = tagId
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

        public async Task<ResponseModel<string>> UpdatedAsync(ProjectVM project)
        {
            var tagid= Guid.NewGuid();
            if(project.TagTitle != null && project.TagTitle != "")
            {
                var tagdata= await _tagService.GetByTitleAsync(project.TagTitle);
                if (tagdata.Data == null)
                {
                    TagModel tag = new TagModel()
                    {
                        Id = tagid,
                        Title = project.TagTitle,
                        Type = TagType.PROJECT
                    };
                   await _tagService.SaveAsync(tag);
                }
                else
                {
                    tagid = tagdata.Data.Id;

                }
            }
            else
            {
                tagid = Guid.Empty;
            }
            ProjectModel existingModel = await _repo.GetByIdAsync(project.Id);
            existingModel.Title = project.Title;
            existingModel.Description = project.Description;
            existingModel.UpdatedOn = DateTime.Now;
            existingModel.UpdatedBy = project.UpdatedBy;
            existingModel.TagId= tagid;
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
