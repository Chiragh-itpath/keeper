using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;

namespace Keeper.Services.Services.Interfaces
{
    public interface ITagService
    {
        ResponseModel<IList<TagModel>> GetAll(Guid userId);
        Task<TagModel?> GetByIdAsync(Guid id);
        Task<TagModel?> AddAsync(string? tag, Guid userId,TagType type);
    }
}
