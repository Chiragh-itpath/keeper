using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface ITagRepo
    {
        Task<ResponseModel> Delete(Guid id);
        Task<ResponseModel> Get();
        Task<ResponseModel> Get(Guid Id);
        Task<ResponseModel> Get(TagType type);
        Task<ResponseModel> Get(string title);
        Task<ResponseModel> Post(TagModel tag);
    }
}
