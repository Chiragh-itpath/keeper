using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepo _repo;
        public TagService(ITagRepo tagRepo)
        {
            _repo = tagRepo;
        }
        public ResponseModel<IList<TagModel>> GetAll(Guid userId)
        {
            var tags = _repo.GetAll(userId);
            return new ResponseModel<IList<TagModel>>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "",
                Data = tags
            };
        }
        public async Task<TagModel?> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public async Task<TagModel?> AddAsync(string? tag, Guid userId, TagType type)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return null;
            }
            var res = _repo.GetAll(userId).FirstOrDefault(x => x.Title.Equals(tag) && x.Type == type);
            if (res == null)
            {
                return await _repo.AddAsync(new TagModel()
                {
                    Title = tag,
                    UserId = userId,
                    Type = type
                });
            }
            return res;
        }
    }
}
