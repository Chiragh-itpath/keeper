using Keeper.Common.Response;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;

namespace Keeper.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<ResponseModel<string>> RegisterUser(RegisterVM register);
        Task<UserModel> GetUserByEmail(string email);
        Task<ResponseModel<TokenModel>> Login(LoginVM loginVM);
    }
}
