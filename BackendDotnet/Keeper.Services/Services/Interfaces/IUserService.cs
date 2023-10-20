using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel<UserViewModel>> GetByIdAsync(Guid id);
        Task<ResponseModel<UserViewModel>> CheckEmail(string email);
    }
}
