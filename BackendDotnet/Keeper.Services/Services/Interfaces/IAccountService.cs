using Keeper.Common.Response;
using Keeper.Common.ViewModels;

namespace Keeper.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseModel<string>> RegisterAsync(RegisterModel register);
        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginVM);
        Task<ResponseModel<string>> GetOTP(string email);
        Task<ResponseModel<string>> UpdatePasswordAsync(PasswordResetModel resetModel);
    }
}
