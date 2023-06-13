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
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get()
        {
            var data=await _tagRepo.Get();
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<TagModel>> Get(Guid Id)
        {
            var data=await _tagRepo.Get(Id);
            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record", IsSuccess = true, Data = data };
        }
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get(TagType type)
        {
            var data= await _tagRepo.Get(type); 
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<IEnumerable<TagModel>>> Get(string title)
        {
            var data = await _tagRepo.Get(title);
            return GetResponse(StatusType.SUCCESS, "List of Records", true, data);
        }
        public async Task<ResponseModel<TagModel>> Post(TagModel tagModel)
        {
            tagModel.Id= Guid.NewGuid();
            var data= await _tagRepo.Post(tagModel);

            return new ResponseModel<TagModel>() { StatusName = StatusType.SUCCESS, Message = "Record Inserted", IsSuccess = true, Data = data };
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _tagRepo.Delete(id);
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
