using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services
{
    public class TagService:ITagService
    {
        private readonly ITagRepo _tagRepo;
        public TagService(ITagRepo tagRepo)
        {
            _tagRepo = tagRepo;
        }
        public async Task<ResponseModel<IEnumerable<TagModel>>> GetAllAsync()
        {
            var data=await _tagRepo.GetAllAsync();
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<TagModel>> GetByIdAsync(Guid Id)
        {
            var data=await _tagRepo.GetByIdAsync(Id);
            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record", IsSuccess = true, Data = data };
        }
        public async Task<ResponseModel<IEnumerable<TagModel>>> GetByTypeAsync(TagType type)
        {
            var data= await _tagRepo.GetByTypeAsync(type); 
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<IEnumerable<TagModel>>> GetByTitleAsync(string title)
        {
            var data = await _tagRepo.GetByTitleAsync(title);
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<TagModel>> SaveAsync(TagModel tagModel)
        {
            tagModel.Id= Guid.NewGuid();
            var data= await _tagRepo.SaveAsync(tagModel);

            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record Inserted", IsSuccess = true, Data = data };
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _tagRepo.DeleteByIdAsync(id);
        }
        ResponseModel<IEnumerable<TagModel>> GetResponse(StatusType statusName, string message, bool isSuccess, IEnumerable<TagModel>? data = null, object? metadata = null)
        {
            return new ResponseModel<IEnumerable<TagModel>>()
            {
                StatusName=statusName,
                Message = message,
                IsSuccess = isSuccess,
                Data = data,
            };
        }
    }
}
