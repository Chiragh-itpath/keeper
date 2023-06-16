using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByEmailAsync(string email);
        Task<ResponseModel<UserVM>> GetByIdAsync(Guid id);
    }
}
