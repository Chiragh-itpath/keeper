using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IItemService
    {
        Task<ResponseModel<List<ItemViewModel>>> GetAllAsync(Guid Keepid);
        Task<ResponseModel<ItemViewModel>> GetAsync(Guid id);
        Task<ResponseModel<ItemViewModel>> SaveAsync(AddItem addItem,Guid userId);
        Task<ResponseModel<ItemViewModel>> UpdateAsync(EditItem editItem, Guid userId);
        Task<ResponseModel<string>> DeleteAsync(Guid id);
        
    }
}
