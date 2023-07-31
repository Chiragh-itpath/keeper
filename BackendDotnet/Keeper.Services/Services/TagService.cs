using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepo _tagRepo;
        public TagService(ITagRepo tagRepo)
        {
            _tagRepo = tagRepo;
        }
        public async Task<ResponseModel<List<TagVM>>> GetAllAsync()
        {
            var data = await _tagRepo.GetAllAsync();
            return GetResponse(StatusType.SUCCESS, "List of Records", true, ConvertToVM(data));
        }
        public async Task<ResponseModel<TagModel>> GetByIdAsync(Guid Id)
        {
            var data = await _tagRepo.GetByIdAsync(Id);
            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record", IsSuccess = true, Data = data };
        }
        public async Task<ResponseModel<List<TagVM>>> GetByTypeAsync(TagType type)
        {
            var data = await _tagRepo.GetByTypeAsync(type);
            return GetResponse(StatusType.SUCCESS, "List of Records", true, ConvertToVM(data));
        }
        public async Task<ResponseModel<TagModel>> GetByTitleAsync(string title)
        {
            var data = await _tagRepo.GetByTitleAsync(title);
            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record", IsSuccess = true, Data = data };
        }
        public async Task<ResponseModel<TagModel>> SaveAsync(TagModel tagModel)
        {
            var data = await _tagRepo.SaveAsync(tagModel);

            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record Inserted", IsSuccess = true, Data = data };
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _tagRepo.DeleteByIdAsync(id);
        }
        ResponseModel<List<TagVM>> GetResponse(StatusType statusName, string message, bool isSuccess, List<TagVM>? data = null, object? metadata = null)
        {
            return new ResponseModel<List<TagVM>>()
            {
                StatusName = statusName,
                Message = message,
                IsSuccess = isSuccess,
                Data = data,
            };
        }
        List<TagVM> ConvertToVM(IEnumerable<TagModel> data)
        {
            List<TagVM> list = new List<TagVM>();
            foreach (var item in data)
            {
                list.Add(new TagVM() { Title = item.Title, Type = item.Type });
            }
            return list;
        }

        public async Task<ResponseModel<List<TagVM>>> GetForProjectAsync(Guid userid)
        {
            var data = await _tagRepo.GetForProjectAsync(userid);
            return GetResponse(StatusType.SUCCESS, "List of Records", true, ConvertToVM(data));
        }

        public async Task<ResponseModel<List<TagVM>>> GetForKeepsAsync(Guid userid, Guid projectid)
        {
            var data = await _tagRepo.GetForKeepAsync(userid, projectid);
            return GetResponse(StatusType.SUCCESS, "List of Records", true, ConvertToVM(data));
        }
    }
}
