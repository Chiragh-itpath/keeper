using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services.Interfaces
{
    public interface IKeepService
    {
        Task<ResponseModel<string>> SaveAsync(KeepVM keep);
        Task<ResponseModel<List<KeepModel>>> GetAllAsync(Guid ProjectId);
        Task<ResponseModel<KeepModel>> GetByIdAsync(Guid Id);
        Task<ResponseModel<string>> DeleteByIdAsync(Guid Id);
        Task<ResponseModel<string>> UpdatedAsync(KeepVM keep);
        Task<ResponseModel<List<KeepModel>>> GetByTagAsync(Guid userId, Guid tagId);
        Task<ResponseModel<IEnumerable<KeepModel>>> SharedKeepsAsync(Guid userId);
    }
}
