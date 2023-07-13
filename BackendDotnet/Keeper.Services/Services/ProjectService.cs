using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;


namespace Keeper.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly ITagService _tagService;
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        public ProjectService(IProjectRepo repo, ITagService tagService,IUserRepo userRepo, IMailService mailService)
        {
            _repo = repo;
            _tagService = tagService;
            _userRepo = userRepo;
            _mailService = mailService;
        }
        public async Task<ResponseModel<string>> SaveAsync(ProjectVM projectVM)
        {
            List<UserModel> users = new();
            List<ProjectModel> projects = new();
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
                tagId = Guid.Empty;

            ProjectModel model = new ProjectModel
            {
                Title = projectVM.Title,
                Description = projectVM.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = projectVM.CreatedBy,
                TagId = tagId
            };
            UserModel user = await _userRepo.GetByIdAsync(model.CreatedBy);
            users.Add(user);
            projects.Add(model);

            model.Users = users;
            user.Projects = projects;
            _userRepo.UpdateUser(user);
            var result=await _repo.SaveAsync(model);
            if (projectVM.Mail != null)
            {
                MailRequest mail = projectVM.Mail;
                foreach(var mailid in mail.ToEmail)
                {
                    UserModel userdata = await _userRepo.GetByEmailAsync(mailid);
                    users.Add(userdata);
                    result.Users = users;
                    userdata.Projects = projects;
                    _userRepo.UpdateUser(userdata);
                    _repo.UpdatedAsync(result);
                }
                    mail.TypeId = result.Id;
                    await _mailService.SendEmailAsync(mail);
            }
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "Project Created Suceessfully",
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
            if (project.Mail != null)
            {
                MailRequest mail = project.Mail;
                mail.TypeId = project.Id;
                await _mailService.SendEmailAsync(mail);
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

        public async Task<ResponseModel<List<ProjectModel>>> GetByTagAsync(Guid userId,Guid tagId)
        {
            var result=await _repo.GetByTagAsync(userId,tagId);
            return new ResponseModel<List<ProjectModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };
        }
    }
}
