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
        Task<bool> Delete(Guid id);
        Task<ResponseModel<IEnumerable<TagModel>>> Get();
        Task<ResponseModel<TagModel>> Get(Guid Id);
        Task<ResponseModel<IEnumerable<TagModel>>> Get(TagType type);
        Task<ResponseModel<IEnumerable<TagModel>>> Get(string title);
        Task<ResponseModel<TagModel>> Post(TagModel tagModel);
    }
}
