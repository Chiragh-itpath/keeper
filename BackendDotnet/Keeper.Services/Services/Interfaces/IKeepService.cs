using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IKeepService
    {
        Task<ResponseModel<List<KeepViewModel>>> GetAllAsync(Guid projectId, Guid userId);
        Task<ResponseModel<KeepViewModel>> GetAsync(Guid id);
        Task<ResponseModel<KeepViewModel>> AddAsync(AddKeep addKeep,Guid userId);
        Task<ResponseModel<KeepViewModel>> UpdateAsync(EditKeep editKeep, Guid userId);
        Task<ResponseModel<string>> DeleteAsync(Guid id);
    }
}
