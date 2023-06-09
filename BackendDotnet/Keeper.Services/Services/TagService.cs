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
        public async Task<ResponseModel> Get()
        {
            return await _tagRepo.Get();
        }
        public async Task<ResponseModel> Get(Guid Id)
        {
            return await _tagRepo.Get(Id);
        }
        public async Task<ResponseModel> Get(TagType type)
        {
            return await _tagRepo.Get(type);
        }
        public async Task<ResponseModel> Get(string title)
        {
            return await _tagRepo.Get(title);
        }
        public async Task<ResponseModel> Post(TagModel tagModel)
        {
            tagModel.Id= Guid.NewGuid();
            return await _tagRepo.Post(tagModel);
        }
        public async Task<ResponseModel> Delete(Guid id)
        {
            return await _tagRepo.Delete(id);
        }
    }
}
