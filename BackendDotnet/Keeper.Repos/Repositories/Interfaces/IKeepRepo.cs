using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Repos.Repositories.Interfaces
{
    public interface IKeepRepo
    {
        Task<List<KeepModel>> GetAllAsync(Guid projectId);
        Task<KeepModel> GetByIdAsync(Guid Id);
        Task<KeepModel> SaveAsync(KeepModel keep);
        Task<bool> DeleteByIdAsync(Guid keepid);
        Task<bool> UpdatedAsync(KeepModel keepModel);
        Task<List<KeepModel>> GetByTagAsync(Guid userId, Guid tagId);
    }
}
