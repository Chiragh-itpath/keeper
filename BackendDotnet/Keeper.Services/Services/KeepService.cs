using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class KeepService : IKeepService
    {
        private readonly IKeepRepo _keepRepo;
        private readonly IProjectRepo _projectRepo;
        private readonly IProjectShareRepo _projectShareRepo;
        private readonly ITagService _tag;
        public KeepService(IKeepRepo keepRepo, ITagService tagService, IProjectRepo projectRepo, IProjectShareRepo projectShareRepo)
        {
            _keepRepo = keepRepo;
            _tag = tagService;
            _projectRepo = projectRepo;
            _projectShareRepo = projectShareRepo;
        }
        public async Task<ResponseModel<List<KeepViewModel>>> GetAllAsync(Guid projectId, Guid userId)
        {
            List<KeepModel> result;
            var project = await _projectRepo.GetByIdAsync(projectId);
            var sharedProject = await _projectShareRepo.GetAsync(projectId, userId);
            if (project?.CreatedById == userId || sharedProject != null)
                result = await _keepRepo.GetAllAsync(projectId);
            else
                result = await _keepRepo.GetAllShared(projectId, userId);

            var keeps = result.Select(item => new KeepViewModel
            {
                Id = item.Id,
                Title = item.Title,
                ProjectId = item.ProjectId,
                CreatedBy = item.CreatedBy.Email,
                CreatedOn = item.CreatedOn,
                Updatedby = item.UpdatedBy?.Email,
                UpdatedOn = item.UpdatedOn,
                Tag = item.Tag?.Title,
            }).ToList();

            return new ResponseModel<List<KeepViewModel>>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = keeps
            };
        }
        public async Task<ResponseModel<KeepViewModel>> GetAsync(Guid id)
        {
            var result = await _keepRepo.GetAsync(id);
            if (result == null)
            {
                return new ResponseModel<KeepViewModel>()
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "No Keep Found"
                };
            }
            KeepViewModel keep = new()
            {
                Id = result.Id,
                Title = result.Title,
                ProjectId = result.ProjectId,
                CreatedBy = result.CreatedBy.Email,
                CreatedOn = result.CreatedOn,
                Updatedby = result.UpdatedBy?.Email,
                UpdatedOn = result.UpdatedOn,
                Tag = result.Tag?.Title,
            };
            return new ResponseModel<KeepViewModel>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = keep
            };
        }
        public async Task<ResponseModel<KeepViewModel>> AddAsync(AddKeep addKeep, Guid userId)
        {
            KeepModel keep = new()
            {
                Title = addKeep.Title,
                ProjectId = addKeep.ProjectId,
                CreatedById = userId,
                CreatedOn = DateTime.Now,
            };

            if (!string.IsNullOrEmpty(addKeep.Tag))
            {
                var project = await _projectRepo.GetByIdAsync(addKeep.ProjectId);
                var tag = await _tag.AddAsync(addKeep.Tag, project!.CreatedById, TagType.KEEP);
                keep.TagId = tag?.Id;
            }
            var keepId = await _keepRepo.SaveAsync(keep);
            var res = await GetAsync(keepId);
            res.Message = "Keep Added";
            return res;
        }
        public async Task<ResponseModel<KeepViewModel>> UpdateAsync(EditKeep editKeep, Guid userId)
        {
            var keep = await _keepRepo.GetAsync(editKeep.Id);
            if (keep == null)
            {
                return new ResponseModel<KeepViewModel>()
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "No Keep Found"
                };
            }
            keep.Title = editKeep.Title;
            keep.UpdatedOn = DateTime.Now;
            keep.UpdatedById = userId;
            if (!string.IsNullOrEmpty(editKeep.Tag))
            {
                var project = await _projectRepo.GetByIdAsync(editKeep.ProjectId);
                var tag = await _tag.AddAsync(editKeep.Tag, project!.CreatedById, TagType.KEEP);
                keep.TagId = tag?.Id;
            }
            else
            {
                keep.TagId = null;
            }
            var keepId = await _keepRepo.UpdateAsync(keep);
            var res = await GetAsync(keepId);
            res.Message = "Keep Updated";
            return res;

        }
        public async Task<ResponseModel<string>> DeleteAsync(Guid id)
        {
            var keep = await _keepRepo.GetAsync(id);
            if (keep == null)
            {
                return new ResponseModel<string>()
                {
                    StatusName = StatusType.NOT_FOUND,
                    IsSuccess = false,
                    Message = "No Keep Found"
                };
            }
            await _keepRepo.DeleteAsync(keep);
            return new ResponseModel<string>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "Keep Deleted",
                Data = id.ToString()
            };
        }
    }
}
