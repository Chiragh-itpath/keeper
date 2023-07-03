using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface ITagService
    {
        Task<ResponseModel<List<TagVM>>> GetAllAsync();
        Task<ResponseModel<TagModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<List<TagVM>>> GetByTypeAsync(TagType type);
        Task<ResponseModel<TagModel>> GetByTitleAsync(string title);
        Task<ResponseModel<TagModel>> SaveAsync(TagModel tagModel);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<ResponseModel<List<TagVM>>> GetByUserAsync(Guid userid, TagType tagType);
    }
}
