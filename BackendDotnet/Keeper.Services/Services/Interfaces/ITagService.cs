using Keeper.Common.Enums;
using Keeper.Common.Response;
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
        Task<bool> DeleteByIdAsync(Guid id);
        Task<ResponseModel<IEnumerable<TagModel>>> GetAllAsync();
        Task<ResponseModel<TagModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<IEnumerable<TagModel>>> GetByTypeAsync(TagType type);
        Task<ResponseModel<IEnumerable<TagModel>>> GetByTitleAsync(string title);
        Task<ResponseModel<TagModel>> SaveAsync(TagModel tagModel);
    }
}
