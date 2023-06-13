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
        Task<bool> Delete(Guid id);
        Task<IEnumerable<TagModel>> Get();
        Task<TagModel> Get(Guid Id);
        Task<IEnumerable<TagModel>> Get(TagType type);
        Task<IEnumerable<TagModel>> Get(string title);
        Task<TagModel> Post(TagModel tag);
    }
}
