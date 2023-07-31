using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;


namespace Keeper.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly ITagService _tagService;
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        private readonly IProjectUserService _projectUserService;
        public ProjectService(IProjectRepo repo, ITagService tagService, IUserRepo userRepo, IMailService mailService, IProjectUserService projectUserService)
        {
            _repo = repo;
            _tagService = tagService;
            _userRepo = userRepo;
            _mailService = mailService;
            _projectUserService = projectUserService;
        }
        public async Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM)
        {
            Guid? tagId = Guid.NewGuid();
            try
            {
                if (projectVM.TagTitle != null && projectVM.TagTitle != "")
                {
                    var tag = await _tagService.GetByTitleAsync(projectVM.TagTitle);
                    if (tag.Data == null)
                    {
                        TagModel tagModel = new TagModel()
                        {
                            Id = tagId.Value,
                            Title = projectVM.TagTitle,
                            Type = TagType.PROJECT,
                        };
                        await _tagService.SaveAsync(tagModel);
                    }
                    else
                    {
                        tagId = tag.Data.Id;
                    }
                }
                else
                    tagId = null;

                ProjectModel model = new ProjectModel
                {
                    Title = projectVM.Title,
                    Description = projectVM.Description,
                    CreatedOn = DateTime.Now,
                    CreatedBy = projectVM.CreatedBy,
                    TagId = tagId
                };
                var result = await _repo.SaveAsync(model);
                if (projectVM.Mail != null)
                {
                    try
                    {
                        projectVM.Mail.TypeId = result.Id;
                        await _mailService.SendEmailAsync(projectVM.Mail);
                    }
                    catch (Exception ex)
                    {
                        return new ResponseModel<string>
                        {
                            StatusName = StatusType.INTERNAL_SERVER_ERROR,
                            IsSuccess = false,
                            Message = ex.Message,
                        };
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return new ResponseModel<string>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Project Created Suceessfully",
            };
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
            List<UserModel> users = new();
            List<ProjectModel> projects = new();
            Guid? tagid = Guid.NewGuid();
            if (project.TagTitle != null && project.TagTitle != "")
            {
                var tagdata = await _tagService.GetByTitleAsync(project.TagTitle);
                if (tagdata.Data == null)
                {
                    TagModel tag = new TagModel()
                    {
                        Id = tagid.Value,
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
                tagid = null;
            }
            ProjectModel existingModel = await _repo.GetByIdAsync(project.Id);
            existingModel.Title = project.Title;
            existingModel.Description = project.Description;
            existingModel.UpdatedOn = DateTime.Now;
            existingModel.UpdatedBy = project.UpdatedBy;
            existingModel.TagId = tagid;
            var result = await _repo.UpdatedAsync(existingModel);
            if (project.Mail != null)
            {
                project.Mail.TypeId = result.Id;
                await _mailService.SendEmailAsync(project.Mail);
            }
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

        public async Task<ResponseModel<List<ProjectModel>>> GetByTagAsync(Guid userId, Guid tagId)
        {
            var result = await _repo.GetByTagAsync(userId, tagId);
            return new ResponseModel<List<ProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };
        }

        public async Task<ResponseModel<IEnumerable<ProjectModel>>> SharedProjects(Guid userId)
        {
            var result = await _repo.SharedProject(userId);
            return new ResponseModel<IEnumerable<ProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "All shared Projects",
                Data = result
            };
        }
    }
}
