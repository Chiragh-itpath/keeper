using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;

namespace Keeper.Services.Services.Interfaces
{
    public interface IItemService
    {
        Task<ResponseModel<ItemModel>> GetByIdAsync(Guid id);
        Task<ResponseModel<string>> DeleteAsync(Guid id);
        Task<ResponseModel<string>> SaveAsync(ItemVM itemVM);
        Task<ResponseModel<string>> UpdateAsync(ItemVM itemVM);
        Task<ResponseModel<IEnumerable<ItemModel>>> GetAllAsync(Guid KeepId);
    }
}
